using API2.Models;

namespace API2.Services
{
    public interface IProjects
    {
        // Students
        Task<List<Students>> GetStudentsAsync();
        Task<Students>GetStudentAsync(Guid id, bool includeStudentsCourses =false);
        Task<Students>AddStudnetsAsync(Students students);
        Task<Students> UpdateStudnetsAsync(Students students);
        Task<(bool, string)>DeleteStudentsAsync(Students students);

        //Courses
        Task<List<Courses>> GetCoursesAsync();
        Task<Courses> GetCourseAsync(Guid id, bool includeStudentsCourses = false);
        Task<Courses> AddCoursesAsync(Courses courses);

        Task<Courses> UpdateCoursesAsync(Courses courses);
        Task<(bool, string)> DeleteCoursesAsync(Courses courses);

        // StudentsCourses
        Task<List<StudentsCourses>>GetStudentsCoursesAsync();

        Task<StudentsCourses> GetStudentscoursesAsync(int id );
        Task<StudentsCourses> AddStudentsCourses(StudentsCourses studentsCourses);
        Task<StudentsCourses> UpdateStudentsCourses(StudentsCourses studentsCourses);

        Task<(bool, string)> DeleteStudentsCoursesAsync(StudentsCourses studentsCourses);
    }
}
