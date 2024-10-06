namespace IdentityCleanArch.Core.Domain.Security.DbEntity;

public class RegistrationRequest
{
        public string Email { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }
}
