using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using SkillSync.Dtos;
using SkillSync.Models;
using SkillSync.Services.Interfaces;

namespace SkillSync.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserModel> _userManager;
        public AuthService(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }
        /// <summary>
        /// Use this method for registering users in the system.
        /// provide RegisterDto in it's parameter.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns> boolean </returns>
        public async Task<bool> RegisterUser(RegisterDto dto)
        {
            string userName = String.Concat(dto.FirstName, dto.LastName);
            var user = new UserModel
            {
                UserName = userName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;

        }
        /// <summary>
        /// If email exists, this method checks the password with the given password and validate if user is authenticated or not.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        public async Task<bool> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) {
                return false;
            }

            if(!await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                return false;
            }

            return true ;

        }
    }
}
