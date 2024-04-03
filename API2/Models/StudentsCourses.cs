namespace API2.Models
{
    public class StudentsCourses
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public Students? student { get; set; }
        public Guid CoursesId { get; set; }
        public Courses? course { get; set; }
    }
}
