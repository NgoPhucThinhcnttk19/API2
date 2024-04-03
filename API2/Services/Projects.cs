using Microsoft.EntityFrameworkCore;
using API2.Data;
using API2.Services;
using API2.Models;
namespace API2.Services
{
    public class Projects : IProjects
    {
        private readonly AppDbContext _context;
        public Projects(AppDbContext context)
        {
            _context = context;
        }
        #region Courses
        public async Task<List<Courses>> GetCoursesAsync()
        {
            try
            {
                return await _context.Courses.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Courses> GetCourseAsync(Guid id,bool includeStudentsCourses)
        {
            try 
            {
                if (includeStudentsCourses)
                {
                    return await _context.Courses.Include(a => a.StudentsCourses)
                        .FirstOrDefaultAsync(i => i.CoursesId == id);
                }
                return await _context.Courses.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Courses> AddCoursesAsync(Courses courses)
        {
            try
            {
                await _context.Courses.AddAsync(courses);
                await _context.SaveChangesAsync();
                return await _context.Courses.FindAsync(courses.CoursesId); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Courses> UpdateCoursesAsync(Courses courses)
        {
            try
            {
                _context.Entry(courses).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return courses;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<(bool, string)> DeleteCoursesAsync(Courses courses)
        {
            try
            {
                var dbCourses = await _context.Courses.FindAsync(courses.CoursesId );

                if (dbCourses == null)
                {
                    return (false, "Courses could not be found");
                }

                _context.Courses.Remove(courses);
                await _context.SaveChangesAsync();

                return (true, "Courses got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }
        #endregion Courses



        #region Students
        public async Task<List<Students>> GetStudentsAsync()
        {
            try
            {
                return await _context.Students.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Students> GetStudentAsync(Guid id, bool includeStudentsCourses)
        {
            try
            {
                if (includeStudentsCourses)
                {
                    return await _context.Students.Include(c => c.StudentsCourses)
                        .FirstOrDefaultAsync(i => i.StudentId == id);
                }
                return await _context.Students.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Students> AddStudnetsAsync(Students students)
        {
            try
            {
                await _context.Students.AddAsync(students);
                await _context.SaveChangesAsync();
                return await _context.Students.FindAsync(students.StudentId); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }
        public async Task<Students> UpdateStudnetsAsync(Students students)
        {
            try
            {
                _context.Entry(students).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return students;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<(bool, string)> DeleteStudentsAsync(Students students)
        {
            try
            {
                var dbStudent = await _context.Courses.FindAsync(students.StudentId);

                if (dbStudent == null)
                {
                    return (false, "Student could not be found");
                }

                _context.Students.Remove(students);
                await _context.SaveChangesAsync();

                return (true, "Student got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }
        #endregion Students


        #region StudentsCourses
        public async Task<List<StudentsCourses>> GetStudentsCoursesAsync()
        {
            try
            {
                return await _context.StudentsCourses.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<StudentsCourses> AddStudentsCourses(StudentsCourses studentsCourses)
        {
            try
            {
                await _context.StudentsCourses.AddAsync(studentsCourses);
                await _context.SaveChangesAsync();
                return await _context.StudentsCourses.FindAsync(studentsCourses); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }
      
            public async Task<StudentsCourses> UpdateStudentsCourses(StudentsCourses studentsCourses)
        {
            try
            {
                _context.Entry(studentsCourses).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return studentsCourses;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<(bool, string)> DeleteStudentsCoursesAsync(StudentsCourses studentsCourses)
        {
            try
            {
                var dbStudentCourses = await _context.Courses.FindAsync(studentsCourses.Id);

                if (dbStudentCourses== null)
                {
                    return (false, "Author could not be found");
                }

                _context.StudentsCourses.Remove(studentsCourses);
                await _context.SaveChangesAsync();

                return (true, "Author got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }
        public async Task<StudentsCourses> GetStudentscoursesAsync(int id)
        {
            try
            {
                return await _context.StudentsCourses.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion StudentsCourses
    }
}
