using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TheBulbProject.DataAccess.DataContext;
using TheBulbProject.Domain.DTOs.CreateDTOs;
using TheBulbProject.Service.Interface;
using TheBulbProject.Service.utils;

namespace TheBulbProject.Service.Repository
{
    public class LoginRepository(AppDBcontext _appDBcontext, IOptions<BaseSetup> _setup) : ILoginRepository
    {    
        private readonly AppDBcontext _appDBcontext = _appDBcontext;
        private readonly BaseSetup _setup = _setup.Value;
        public async Task<string> Login(Login login)
        {
            try
            {
                var checkuser = await _appDBcontext.Profiles.FirstOrDefaultAsync(x => x.Email == login.Email);
                var password = Helper.DecryptPassword(login.Password, checkuser!.PasswordHash);
                if(checkuser == null || !password)
                {
                    throw new Exception("Invalid email or password,please try again");
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new("Email",checkuser.Email),
                        new("Role", checkuser.Role),
                        new("Firstname",checkuser.FirstName)
                    };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_setup.SecretKey));
                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _setup.Issuer,
                        signingCredentials: credentials,
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(20)
                        );
                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return jwtToken;
                }

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
