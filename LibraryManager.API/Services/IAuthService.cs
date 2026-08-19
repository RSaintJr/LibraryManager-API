using LibraryManager.API.DTOs;

namespace LibraryManager.API.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterUserDto dto);
        Task<string> LoginAsync(LoginUserDto dto);
    }
}