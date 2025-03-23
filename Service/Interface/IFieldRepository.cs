using TheBulbProject.Domain.DTOs.CreateDTOs;
using TheBulbProject.Domain.DTOs.UpdateDTOs;
using TheBulbProject.Domain.Model;

namespace TheBulbProject.Service.Interface
{
    public interface IFieldRepository
    {
        Task <string> CreateField (CreateFieldDTO createFieldDTO);
        Task<string> UpdateField (int  fieldId, UpdateFieldDTO createFieldDTO );
        Task<bool> DeleteField (int fieldId);
        Task<Field> GetFieldById (int fieldId);
        Task<List<Field>> GetListOfFieldByFormID(int formID);
        
    }
}
