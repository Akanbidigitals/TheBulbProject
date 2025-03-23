using TheBulbProject.Domain.DTOs.CreateDTOs;
using TheBulbProject.Domain.Model;

namespace TheBulbProject.Service.Interface
{
    public interface IFieldResponseRepository
    {
        Task<string> createResponse(CreateFieldResponseDTO createFieldResponseDTO);
        Task<FieldResponse> GetresponsebyID( int fieldID);

        Task<List<FieldResponse>> GetAllReponses();
        
            
    }
}
