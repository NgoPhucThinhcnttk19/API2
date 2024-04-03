using System.ComponentModel.DataAnnotations;
namespace API2.Models
{
    public class Students
    {
        [Key]
        public Guid StudentId { get; set; }
        public string? Name { get; set; }

        public List<StudentsCourses>? StudentsCourses { get; set; }
    }
}
