using TheBulbProject.Domain.Model;

namespace TheBulbProject.Domain.DTOs.CreateDTOs
{
    public class CreateFieldDTO
    {
        public string Label { get; set; }
        public string Placeholder { get; set; } = "";
        public List<string> Options { get; set; }
      
        public int FormID { get; set; }
    }
}
