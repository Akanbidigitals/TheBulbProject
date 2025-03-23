using Microsoft.AspNetCore.Mvc;
using TheBulbProject.Domain.DTOs.UpdateDTOs;
using TheBulbProject.Domain.Model;
using TheBulbProject.Service.Interface;

namespace TheBulbProject.Controllers
{
    [ApiController]
    [Route("/api/profile")]
    public class ProfileController(ISignUpRepository _ctx) : Controller
    {
        private readonly ISignUpRepository _ctx = _ctx;

        [HttpGet("{email}")]
        public async Task<ActionResult<Profile>> Get([FromRoute]string email)
        {
            var result = await _ctx.GetProfile(email);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateProfile updateProfile)
        {
            var result = await _ctx.UpdateProfile(updateProfile);
            return Ok(result);
        }
        [HttpDelete("{email}")]
        public async Task <IActionResult> Delete([FromRoute]string email)
        {
            var result = await _ctx.DeleteProfile(email);
            return Ok(result);
        }      
       
    }
}
