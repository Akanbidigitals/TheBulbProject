using System.ComponentModel.DataAnnotations;

namespace TheBulbProject.Domain.Model
{
    public class Field
    {
        [Key]
        public int Id { get; set; }
        public string? Label { get; set; }
        public string? Placeholder { get; set; } 
        public List<string>? Options { get; set; } 
        public int MaxRating { get; set; } = 5;
        public int FormID { get; set; }
        //public Form Form { get; set; }
        public ICollection<FieldResponse>? FieldResponses { get; set; }
    }
}
