using System;
namespace Shared.DTO;

    //public record UserDto (string FirstName,string LastName, string Role, bool IsBlocked, bool IsProfile);

    public record UserDto
    {
        public string Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Role { get; set; }
        public bool IsBlocked { get; init; }
    }



