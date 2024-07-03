using JWT.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWT.Api.DAL
{
    public sealed class AppDbContext:IdentityDbContext<AppUser,IdentityRole<Guid>,Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
       
    }
}
