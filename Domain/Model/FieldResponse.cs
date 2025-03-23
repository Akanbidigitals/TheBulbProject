using System.ComponentModel.DataAnnotations;

namespace TheBulbProject.Domain.Model
{
    public class FieldResponse
    {
        [Key]
        public int Id { get; set; }
        public string? Message {  get; set; }
        public string? status { get; set; } 
        public string? SubmisionID { get; set; }
        public int RatingValue { get; set; }
        public int FieldID { get; set; }
        public string RespondedAt { get; set; } = DateTime.Now.ToString("G");
       
    }
}
