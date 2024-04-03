using API2.Models;
using API2.Services;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {

        private readonly IProjects _projects;

        public CoursesController(IProjects projects)
        {
            _projects = projects;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _projects.GetCoursesAsync();

            if (courses == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No Courses in database");
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCourse(Guid id, bool includeStudentsCourses = false)
        {
            Courses courses = await _projects.GetCourseAsync(id, includeStudentsCourses);

            if (courses == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Student found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }

        [HttpPost]
        public async Task<ActionResult<Courses>> AddCourse(Courses courses)
        {
            var dbCou = await _projects.AddCoursesAsync(courses);

            if (dbCou == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.CoursesName} could not be added.");
            }

            return CreatedAtAction("GetStudent", new { id =courses.CoursesId }, courses);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCourse(Guid id, Courses courses)
        {
            if (id != courses.CoursesId)
            {
                return BadRequest();
            }

            Courses dbCou = await _projects.UpdateCoursesAsync(courses);

            if (dbCou == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.CoursesName} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCourses(Guid id)
        {
            var course = await _projects.GetCourseAsync(id, false);
            (bool status, string message) = await _projects.DeleteCoursesAsync(course);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, course);
        }
    }
}

