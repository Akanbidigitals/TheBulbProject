using Microsoft.AspNetCore.Mvc;
using TheBulbProject.Domain.DTOs.CreateDTOs;
using TheBulbProject.Service.Interface;

namespace TheBulbProject.Controllers
{
    public class Login_SignupController(ISignUpRepository _signupRepo,ILoginRepository _loginRepo) : Controller
    {
         private readonly ILoginRepository _loginRepo = _loginRepo;
         private readonly ISignUpRepository _signupRepo = _signupRepo;

        [HttpPost("SiginUp")]
        public async Task<IActionResult> Signup([FromBody] SignUp signUp)
        {
            var result = await _signupRepo.SignUp(signUp);
            return Ok(result);
        }

        [HttpPost("Login")]
        public   async Task <IActionResult> Login([FromBody] Login login )
        {
            var result = await _loginRepo.Login(login);
            return Ok(result);
        }
    }
}
