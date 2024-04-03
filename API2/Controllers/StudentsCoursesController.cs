using API2.Models;
using API2.Services;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsCoursesController : ControllerBase
    {
       
            private readonly IProjects _projects;

            public StudentsCoursesController(IProjects projects)
            {
                _projects = projects;
            }

            [HttpGet]
            public async Task<IActionResult> GetStudentsCourses()
            {
                var StudentsCourses = await _projects.GetStudentsCoursesAsync();
                if (StudentsCourses == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "No StudentsCourses in database.");
                }

                return StatusCode(StatusCodes.Status200OK, StudentsCourses);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetStudentsCourses(int id)
            {
            StudentsCourses studentsCourses = await _projects.GetStudentscoursesAsync(id);

                if (studentsCourses == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"No book found for id: {id}");
                }

                return StatusCode(StatusCodes.Status200OK, studentsCourses);
            }

            
           

            

            
        }
    }

