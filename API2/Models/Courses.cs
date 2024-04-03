using System.ComponentModel.DataAnnotations;
namespace API2.Models
{
    public class Courses
    {
        [Key]
        public Guid CoursesId { get; set; }
        public string? CoursesName { get; set; }
        public string ? Description { get; set; }
        public List<StudentsCourses>? StudentsCourses { get; set; }
    }
}
