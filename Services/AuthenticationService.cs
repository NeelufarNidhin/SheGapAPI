using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Entities.ConfigurationModels;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Shared.DTO;

namespace Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly IOptions<ClientConfiguration> _clientOptions;
        private readonly ClientConfiguration _clientConfiguration;
        private readonly IEmailSender _emailSender;
        private readonly IUrlHelperFactory _urlHelperFactory;


        private User? _user;

        public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IEmailSender emailSender, IUrlHelperFactory urlHelperFactory)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _jwtConfiguration = new JwtConfiguration();
            _configuration.Bind(_jwtConfiguration.Section, _jwtConfiguration);
            _emailSender = emailSender;
            //_clientOptions = clientOptions;
            //_clientConfiguration = _clientOptions.Value;
            _urlHelperFactory = urlHelperFactory;



        }

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();

            _user.RefreshToken = refreshToken;

            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


            return new TokenDto(accessToken, refreshToken);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                //new Claim(ClaimTypes.Email, _user.Email)
                new Claim(ClaimTypes.Name,_user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }


        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtConfiguration.ValidIssuer,
                audience: _jwtConfiguration.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }

        public async Task<IdentityResult> RegisterUser(UserRegistrationDto model)
        {
            // var user = _mapper.Map<User>(userRegistrationDto); 
            User user = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                NormalizedUserName = model.UserName.ToUpper(),
                Role = model.Role,
                TwoFactorEnabled = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);

            }




            return result;
        }

        //public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication)
        //{
        //    _user = await _userManager.FindByNameAsync(userForAuthentication.UserName);


        //    var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuthentication.Password));
        //    if (!result)
        //        _logger.LogWarn($"{nameof(ValidateUser)} : Authentication failed. Wrong username or password");

        //    return result;
        //}

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }


        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"])),
                ValidateLifetime = true,
                ValidIssuer = _jwtConfiguration.ValidIssuer,
                ValidAudience = _jwtConfiguration.ValidAudience
            };


            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);


            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null ||
                    !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;

        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

            var user = await _userManager.FindByNameAsync(principal.Identity.Name);

            if (user == null || user.RefreshToken != tokenDto.Refreshtoken || user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequest();

            _user = user;
            return await CreateToken(populateExp: false);
        }

        public async Task<bool> Login(UserForAuthenticationDto model)
        {


            _user = await _userManager.FindByEmailAsync(model.Email);



            if (_user.TwoFactorEnabled)
            {

                var result = (_user != null && await _userManager.CheckPasswordAsync(_user, model.Password));
                if (!result)
                    _logger.LogWarn($"{nameof(Login)} : Authentication failed. Wrong username or password");

                var otptoken = await _userManager.GenerateTwoFactorTokenAsync(_user, "Email");
                await _emailSender.SendEmailAsync(_user.Email, "OTP Confirmation", otptoken);

                return true;


            }

            return false;
        }



        public async Task<bool> ConfirmEmail(VerifyEmailDto emailDto)
        {

            _user = await _userManager.FindByIdAsync(emailDto.UserId);
            if (_user != null)
            {
                var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(emailDto.Code));
                var result = await _userManager.ConfirmEmailAsync(_user, code);
                return result.Succeeded;
            }
            return false;
        }

        public async Task<bool> LoginWithOTP(OtpLoginDto model)
        {
            _user = await _userManager.FindByEmailAsync(model.Email);

            // Verify the OTP using the user's email
            var result = await _userManager.VerifyTwoFactorTokenAsync(_user, "Email", model.Otp);

            if (result)
            {
                // OTP verification succeeded

                if (_user != null)
                {

                    return true;
                }
            }

            // OTP verification failed



            return false;
        }

        public async Task<bool> ResendOTP(ResendOtpDto model)
        {
            _user = await _userManager.FindByEmailAsync(model.Email);

            if (_user != null)
            {
                var otptoken = await _userManager.GenerateTwoFactorTokenAsync(_user, "Email");


                // Update the user's OTP (if necessary)
                // You might have to adjust this according to your implementation
                _user.TwoFactorEnabled = true;
                await _userManager.UpdateAsync(_user);

                // Send the new OTP to the user's email
                await _emailSender.SendEmailAsync(_user.Email, "New OTP", $"Your new OTP is: {otptoken}");
                return true;

            }
            return false;
        }

        public async Task ForgotPasswordAsync(string email)
        {
            _user = await _userManager.FindByEmailAsync(email);
            if (_user == null)
            {
                _logger.LogWarn($"User with email : {email} does not exist.");
                //throw new UserNotFoundException(email);


            }




            var code = await _userManager.GeneratePasswordResetTokenAsync(_user);
            // var otptoken = await _userManager.GenerateTwoFactorTokenAsync(userFromDb, "Email");
            // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var link = $"https://localhost:8001/api/authentication/resetpassword?code={code}&userid={_user.Id}";

            await _emailSender.SendEmailAsync(_user.Email, "Reset Password", $"<h1>Reset Password</h1><p>Click <a href=\"{link}\">here</a> to reset your password.</p>");
        }

        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto resetDto)
        {
            _user = await _userManager.FindByIdAsync(resetDto.UserId);

            if (_user == null)
            {
                _logger.LogWarn($"User with id : {resetDto.UserId} does not exist.");
                //throw new UserNotFoundException(resetDto.UserId);
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(_user);

            // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var result = await _userManager.ResetPasswordAsync(_user, code, resetDto.NewPassword);

            if (result.Succeeded)
            {
                await _emailSender.SendEmailAsync(_user.Email, "Password Reset Complete", $"<p>Your password has been reset successfully.</p>");
            }

            return result;
        }
    }
}

