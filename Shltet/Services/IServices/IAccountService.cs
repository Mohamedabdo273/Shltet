using Shltet.DTO;

namespace Shltet.Services.IServices
{
    public interface IAccountService
    {
        Task<object> RegisterAsync(ApplicationUserDto userDto);
        Task<object> LoginAsync(LoginDto userVm);
    
    }
}
