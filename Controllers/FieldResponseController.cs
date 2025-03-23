using Microsoft.AspNetCore.Mvc;
using TheBulbProject.Domain.DTOs.CreateDTOs;
using TheBulbProject.Domain.Model;
using TheBulbProject.Service.Interface;

namespace TheBulbProject.Controllers
{
    [ApiController]
    [Route("/api/fieldresponse")]
    public class FieldResponseController(IFieldResponseRepository fieldResponseRepository) : Controller
    {
       private readonly IFieldResponseRepository _fieldRepository = fieldResponseRepository;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateFieldResponseDTO createFieldResponseDTO)
        {
            var result = await _fieldRepository.createResponse(createFieldResponseDTO);
            return Ok(result);  
        }
        [HttpGet("{fieldId}")]
        public async Task<ActionResult<FieldResponse>> GetByID([FromRoute] int fieldId)
        {
            var result = await _fieldRepository.GetresponsebyID(fieldId);
            return Ok(result);
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<FieldResponse>>> GetAll()
        {
            var result = await _fieldRepository.GetAllReponses();
            return result;
        }
    }
}
