using Microsoft.EntityFrameworkCore;
using TheBulbProject.DataAccess.DataContext;
using TheBulbProject.Domain.DTOs.CreateDTOs;
using TheBulbProject.Domain.DTOs.UpdateDTOs;
using TheBulbProject.Domain.Model;
using TheBulbProject.Service.Interface;

namespace TheBulbProject.Service.Repository
{
    public class FieldRepository(AppDBcontext appDBcontext) : IFieldRepository
    {
        private readonly AppDBcontext _appDBcontext = appDBcontext;

        public async Task<string> CreateField(CreateFieldDTO createFieldDTO)
        {
            try
            {
                var checkform = await _appDBcontext.Forms.FirstOrDefaultAsync( x=>x.FormId == createFieldDTO.FormID );
                if (checkform == null)
                {
                    throw new Exception("Form Id does not exist");
                }
                var field = new Field()
                {
                    Label = createFieldDTO.Label,
                    Placeholder = createFieldDTO.Placeholder,
                    FormID = createFieldDTO.FormID,
                    Options = createFieldDTO.Options,
                  


                };
                await _appDBcontext.Fields.AddAsync(field);
                await _appDBcontext.SaveChangesAsync();
                return "Field created successfully";

            }catch(Exception ex)
            {
              throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteField(int fieldId)
        {
            try
            {
                var checkfield = await _appDBcontext.Fields.FirstOrDefaultAsync(x => x.Id == fieldId);
                if (checkfield == null) throw new Exception("Field does not exist");
                 _appDBcontext.Remove(checkfield);
                await _appDBcontext.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Field> GetFieldById(int fieldId)
        {
            try
            {
                var checkfield = await _appDBcontext.Fields.Include(r => r.FieldResponses).FirstOrDefaultAsync(x => x.Id == fieldId);
                if (checkfield == null) throw new Exception("Field does not exist");
                return checkfield;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<List<Field>> GetListOfFieldByFormID(int formID)
        {
            try
            {
               var FieldbyForm = await _appDBcontext.Fields.Where(r => r.FormID == formID).ToListAsync();

                return FieldbyForm;

                
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<string> UpdateField(int fieldId, UpdateFieldDTO createFieldDTO)
        {

            try
            {
                var checkfield = await _appDBcontext.Fields.FirstOrDefaultAsync(x => x.Id == fieldId);
                if (checkfield == null) throw new Exception("Field does not exist");

                checkfield.Id = createFieldDTO.Id;
                checkfield.Label = createFieldDTO.Label;
                checkfield.Options = createFieldDTO.Options;
                checkfield.FormID = createFieldDTO.FormID;

                _appDBcontext.Fields.Update(checkfield);
                await _appDBcontext.SaveChangesAsync();
                return "Field upated successfully";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
          
    }
}
