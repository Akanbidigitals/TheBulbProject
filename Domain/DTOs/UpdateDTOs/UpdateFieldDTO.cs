namespace TheBulbProject.Domain.DTOs.UpdateDTOs
{
    public class UpdateFieldDTO
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Placeholder { get; set; } = "";
        public List<string> Options { get; set; }
        public int RatingValue { get; set; }
        public int FormID { get; set; }
    }
}
