using SkillSync.Dtos;

namespace SkillSync.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(RegisterDto dto);
        Task<bool> Login(LoginDto dto);
    }
}
