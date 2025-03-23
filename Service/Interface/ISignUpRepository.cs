using TheBulbProject.Domain.DTOs.CreateDTOs;
using TheBulbProject.Domain.DTOs.UpdateDTOs;
using TheBulbProject.Domain.Model;

namespace TheBulbProject.Service.Interface
{
    public interface ISignUpRepository
    {
        Task<string> SignUp(SignUp signUp);
        Task<string> UpdateProfile(UpdateProfile updateProfile);
        Task<string> DeleteProfile(string email);
        Task<Profile> GetProfile(string email);
    }
}
