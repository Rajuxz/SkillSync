using Microsoft.AspNetCore.Identity;

namespace SkillSync.Models
{
    public class UserModel:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Bio {  get; set; }
        public string? ProfileUrl {  get; set; }
    }
}
