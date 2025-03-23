using TheBulbProject.Domain.DTOs.CreateDTOs;

namespace TheBulbProject.Service.Interface
{
    public interface ILoginRepository
    {
        Task<string> Login(Login login);
    }
}
