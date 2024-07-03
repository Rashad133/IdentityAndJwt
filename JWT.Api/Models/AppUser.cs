using Microsoft.AspNetCore.Identity;

namespace JWT.Api.Models
{
    public sealed class AppUser:IdentityUser<Guid>
    {
        public string Name { get; set; }=string.Empty;
        public string Surname { get; set; } = string.Empty;
    }
}
