using TheBulbProject.Domain.DTOs.CreateDTOs;
using TheBulbProject.Domain.DTOs.UpdateDTOs;
using TheBulbProject.Domain.Model;

namespace TheBulbProject.Service.Repository
{
    public interface IFormRepository
    {
        Task <string> CreateForm(CreateFormDTO createFormDTO);
        Task <bool> DeleteForm (int id);
        Task<string > UpdateForm(int id, UpdateFormDTO createFormDTO);
        Task<Form> GetFormbyID(int id);
        Task <Form> GetFormbyFormType(string  formType);
        
    }
}
