using Microsoft.AspNetCore.Mvc;
using TheBulbProject.Domain.DTOs.CreateDTOs;
using TheBulbProject.Domain.DTOs.UpdateDTOs;
using TheBulbProject.Domain.Model;
using TheBulbProject.Service.Interface;
using TheBulbProject.Service.Repository;

namespace TheBulbProject.Controllers
{
    [ApiController]
    [Route("/api/field")]
    public class FieldController(IFieldRepository fieldRepository) : Controller
    {
        private readonly IFieldRepository _fieldRepository = fieldRepository;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateFieldDTO _dto)
        {
            var result = await _fieldRepository.CreateField(_dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Field>> Get([FromRoute] int id)
        {
            var result = await _fieldRepository.GetFieldById(id);
            return Ok(result);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> update([FromRoute] int id, UpdateFieldDTO updateFieldDTO)
        {
            var result = await _fieldRepository.UpdateField(id, updateFieldDTO);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteField([FromRoute] int id)
        {
            var result = await _fieldRepository.DeleteField(id);
            return Ok(result);
        }

        [HttpGet("/byformid/{id}")]
        public async Task<ActionResult<List<Field>>> GetFieldByFormId([FromRoute]int id)
        {
            var result = await _fieldRepository.GetListOfFieldByFormID(id);
            return Ok(result);
        }
            
          
    }
}
