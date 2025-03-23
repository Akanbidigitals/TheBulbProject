using System.ComponentModel.DataAnnotations;

namespace TheBulbProject.Domain.Model
{
    public class Form
    {
        [Key]
        public int FormId { get; set; }
        public string? FormType { get; set; }
        public string? FormTitle { get; set; }
        public string CreateTime { get; set; } = DateTime.Now.ToString("G");
        public List<Field> Fields { get; set; } = [];
        public List<FieldResponse> Responses { get; set; } = [];
    }
}
