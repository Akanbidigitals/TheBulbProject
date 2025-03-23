using Microsoft.EntityFrameworkCore;
using TheBulbProject.DataAccess.DataContext;
using TheBulbProject.Domain.DTOs.CreateDTOs;
using TheBulbProject.Domain.DTOs.UpdateDTOs;
using TheBulbProject.Domain.Model;

namespace TheBulbProject.Service.Repository
{
    public class FormRepository(AppDBcontext appDBcontext) : IFormRepository
    {
        private readonly AppDBcontext _appDBContext = appDBcontext;
        public async Task<string> CreateForm(CreateFormDTO createFormDTO)
        {
            try
            {
                var newForm = new Form()
                {
                    FormTitle = createFormDTO.FormTitle.ToLower(),
                    FormType = createFormDTO.FormType.ToLower(),
                };
                await _appDBContext.Forms.AddAsync(newForm);
                await _appDBContext.SaveChangesAsync();
                return "New form created successfully";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<bool> DeleteForm(int id)
        {
            try
            {
                var checkform = await _appDBContext.Forms.FirstOrDefaultAsync(x => x.FormId == id);
                if (checkform == null) throw new Exception("Form Id does not exist");
                _appDBContext.Forms.Remove(checkform);
               await _appDBContext.SaveChangesAsync();
                return true;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<Form> GetFormbyFormType(string formType)
        {
            try
            {
                var checktitle = await _appDBContext.Forms.FirstOrDefaultAsync(f => f.FormType == formType);
                if (checktitle == null) throw new Exception("Form title does not exist");
                return checktitle;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Form> GetFormbyID(int id)
        {

            var checkform = await _appDBContext.Forms.Include(r => r.Fields).Include(r => r.Responses).FirstOrDefaultAsync(x => x.FormId == id);
            if (checkform == null) throw new Exception("Form Id does not exist");
            return checkform;
        }

        public async Task<string> UpdateForm(int id, UpdateFormDTO createFormDTO)
        {
            try
            {
                var checkForm = await _appDBContext.Forms.FirstOrDefaultAsync(x => x.FormId == id);
                if (checkForm == null) throw new Exception("Form Id does not exist");
                checkForm.FormId = id;
                checkForm.FormTitle = createFormDTO.FormTitle;
                checkForm.FormType = createFormDTO.FormType;
                checkForm.CreateTime = DateTime.Now.ToString("G");

                _appDBContext.Forms.Update(checkForm);
                await _appDBContext.SaveChangesAsync();
                return "Form updated successfully";


            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
