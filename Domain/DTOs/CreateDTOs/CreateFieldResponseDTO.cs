using TheBulbProject.Domain.Model;

namespace TheBulbProject.Domain.DTOs.CreateDTOs
{
    public class CreateFieldResponseDTO
    {

        public string Message { get; set; }
        public string status { get; set; }
        public int RatingValue { get; set; } 
        public int FieldID { get; set; }
       
    }
}
