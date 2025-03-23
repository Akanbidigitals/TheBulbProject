using Microsoft.EntityFrameworkCore;
using TheBulbProject.DataAccess.DataContext;
using TheBulbProject.Domain.DTOs.CreateDTOs;
using TheBulbProject.Domain.Model;
using TheBulbProject.Service.Interface;
using TheBulbProject.Service.utils;

namespace TheBulbProject.Service.Repository
{
    public class FieldResponseRepository(AppDBcontext appDBcontext) : IFieldResponseRepository
    {
        private readonly AppDBcontext _appDBcontext = appDBcontext;
        public async Task<string> createResponse(CreateFieldResponseDTO createFieldResponseDTO)
        {
            try
            {
                var newResponse = new FieldResponse()
                {
                    Message = createFieldResponseDTO.Message,
                    status = createFieldResponseDTO.status,
                    FieldID = createFieldResponseDTO.FieldID,
                    SubmisionID = Helper.GenerateRandomTag(),
                   RatingValue = createFieldResponseDTO.RatingValue,
                   
                };

                await _appDBcontext.FieldResponses.AddAsync(newResponse);
                await _appDBcontext.SaveChangesAsync();
                return "Response created";
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<FieldResponse>> GetAllReponses()
        {
            var allresponse = await _appDBcontext.FieldResponses.ToListAsync();
            return allresponse;
        }

        public async Task<FieldResponse> GetresponsebyID( int fieldID)
        {
            try
            {
              

                var checkResponse = await _appDBcontext.FieldResponses.FirstOrDefaultAsync(x => x.FieldID == fieldID);
                if (checkResponse == null) throw new Exception("FieldI does not exist");
                return checkResponse;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
