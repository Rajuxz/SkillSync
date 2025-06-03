using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillSync.Models;

namespace SkillSync.Data
{
    public class AppDbContext : IdentityDbContext<UserModel>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { 
        }
    }
}
