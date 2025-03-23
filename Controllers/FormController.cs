using Microsoft.AspNetCore.Mvc;
using TheBulbProject.Domain.DTOs.CreateDTOs;
using TheBulbProject.Domain.DTOs.UpdateDTOs;
using TheBulbProject.Domain.Model;
using TheBulbProject.Service.Repository;

namespace TheBulbProject.Controllers
{
    [ApiController]
    [Route("/api/form")]
    public class FormController(IFormRepository formRepository) : Controller
    {
        private readonly IFormRepository _formRepository = formRepository;

        [HttpPost]
        public async Task<IActionResult> PostForm([FromBody] CreateFormDTO _dto)
        {
            var result = await _formRepository.CreateForm(_dto);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Form>> GetFormById([FromRoute]int id)
        {
            var result = await _formRepository.GetFormbyID(id);
            return Ok(result);
        }

        [HttpGet("/title/{title}")]
        public async Task<ActionResult<Form>> GetformbyTitle([FromRoute] string title)
        {
            var response = await _formRepository.GetFormbyFormType(title);
            return Ok(response);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateForm([FromRoute] int id, [FromBody] UpdateFormDTO _dto)
        {
            var result = await _formRepository.UpdateForm(id, _dto);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForm([FromRoute,] int id)
        {
            var result = await _formRepository.DeleteForm(id);
            return Ok(result);
        }

    }
}
