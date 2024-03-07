using Interfaces;
using LoggerService;
using Services;
using Repository;
using Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Entities.ConfigurationModels;
using Microsoft.AspNetCore.Identity.UI.Services;
using Services.Utility;

namespace SheGapAPI.Extensions
{
    public static class ServiceExtensions
	{
		public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
		{
            var clientSection = configuration.GetSection("Client");
            var origin_1 = clientSection["Url"];
            var origin_2 = clientSection["Url2"];

            services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				builder.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());
			});

		}

        public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

		
		public static void ConfigureRepositoryManager(this IServiceCollection services) =>
			services.AddScoped<IRepositoryManager, RepositoryManager>();

		public static void ConfigureServiceManager(this IServiceCollection services) =>
			services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureEmailSender(this IServiceCollection services) =>
            services.AddScoped<IEmailSender, EmailSender>();

        public static void AddClientConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ClientConfiguration>(configuration.GetSection("Client"));
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
			services.AddDbContext<RepositoryContext>(opts =>
			opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

		public static void ConfigureIdentity(this IServiceCollection services)
		{
			var builder = services.AddIdentity<User, IdentityRole>(o =>
			{
				o.Password.RequireDigit = true;
				o.Password.RequireLowercase = false;
				o.Password.RequireUppercase = true;
				o.Password.RequiredLength = 10;
				o.Password.RequireNonAlphanumeric = false;
				o.User.RequireUniqueEmail = true;
			}).AddEntityFrameworkStores<RepositoryContext>()
			.AddDefaultTokenProviders();
		}


		public static void ConfigureJWT(this IServiceCollection services,IConfiguration configuration)
		{
			//call the configuration model and bind the section from appsettings
			var jwtConfiguration = new JwtConfiguration();
			configuration.Bind(jwtConfiguration.Section, jwtConfiguration);

			//get the secret key from configuration
			var secretKey = configuration.GetValue<string>("JwtSettings:Secret");

			//register jwt authentication middleware 
			services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options =>
				{					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,

						ValidIssuer = jwtConfiguration.ValidIssuer,
						ValidAudience = jwtConfiguration.ValidAudience,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

					};
				});
		}


		


		
    }

	
}

