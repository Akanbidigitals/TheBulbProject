using Microsoft.EntityFrameworkCore;
using TheBulbProject.DataAccess.DataContext;
using TheBulbProject.Domain.DTOs.CreateDTOs;
using TheBulbProject.Domain.DTOs.UpdateDTOs;
using TheBulbProject.Domain.Model;
using TheBulbProject.Service.Interface;
using TheBulbProject.Service.utils;

namespace TheBulbProject.Service.Repository
{
    public class SignUpRepository(AppDBcontext _appDbContext) : ISignUpRepository
    {
        private readonly AppDBcontext _appDbContext = _appDbContext;

        public async Task<string> DeleteProfile(string email)
        {
            try
            {
                var checkprofile = await _appDbContext.Profiles.FirstOrDefaultAsync(x => x.Email == email);
                if (checkprofile == null) throw new Exception("Account does not exist"); 
                 _appDbContext.Profiles.Remove(checkprofile);
                await _appDbContext.SaveChangesAsync();
                return "Account deleted succeffully";

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Profile> GetProfile(string email)
        {
            try
            {
                var checkprofile = await _appDbContext.Profiles.FirstOrDefaultAsync(x => x.Email == email);
                if (checkprofile == null) throw new Exception("Account does not exist");
                return checkprofile;
            }
            catch(Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> SignUp(SignUp signUp)
        {
            try
            {
                var checkuser = await _appDbContext.Profiles.FirstOrDefaultAsync(x => x.Email == signUp.Email);
                if (checkuser != null)  throw new Exception("Email already exist");
                if(signUp.Password != signUp.ConfirmPassword) throw new Exception("Password does not match");
                var newuser = new Profile()
                {
                    FirstName = signUp.FirstName,
                    LastName   = signUp.LastName,
                    UserId = Helper.GenerateUserId(signUp.FirstName),
                    Email = signUp.Email,
                    PhoneNumber = signUp.PhoneNumber,
                    PasswordHash = Helper.EncryptPassword(signUp.Password),
                    Role = signUp.Role.ToLower(),

                };

                await _appDbContext.Profiles.AddAsync(newuser);
                await _appDbContext.SaveChangesAsync();
                return "Account created successfully";

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> UpdateProfile(UpdateProfile updateProfile)
        {
            try
            {
                var checkprofile = await _appDbContext.Profiles.FirstOrDefaultAsync(x => x.Email == updateProfile.Email);
                if (checkprofile == null) throw new Exception("Account does not exist");

                checkprofile.FirstName = updateProfile.FirstName;
                checkprofile.LastName = updateProfile.LastName;
                checkprofile.Role = updateProfile.Role;
                checkprofile.Email = updateProfile.Email;
                checkprofile.PhoneNumber = updateProfile.PhoneNumber;
                checkprofile.PasswordHash = checkprofile.PasswordHash;

                 _appDbContext.Profiles.Update(checkprofile);
                await _appDbContext.SaveChangesAsync();
                return "Account updated successfully";

            }
            catch( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
