using API2.Services;
using Microsoft.AspNetCore.Mvc;
using API2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace API2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController :ControllerBase
    {
        
        
            private readonly IProjects _projects;

            public StudentsController(IProjects projects)
            {
               _projects = projects;
            }

            [HttpGet]
            public async Task<IActionResult> GetStudents()
            {
                var students = await _projects.GetStudentsAsync();

                if (students == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "No authors in database");
                }

                return StatusCode(StatusCodes.Status200OK, students);
            }

            [HttpGet("id")]
            public async Task<IActionResult> GetStudent(Guid id , bool includeStudentsCourses=false)
            {
                Students students = await _projects.GetStudentAsync(id ,includeStudentsCourses);

                if (students == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"No Student found for id: {id}");
                }

                return StatusCode(StatusCodes.Status200OK, students);
            }

            [HttpPost]
            public async Task<ActionResult<Students>> AddStudent(Students students)
            {
                var dbStu = await _projects.AddStudnetsAsync(students);

                if (dbStu == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"{students.Name} could not be added.");
                }

                return CreatedAtAction("GetStudent", new { id = students.StudentId }, students);
            }

            [HttpPut("id")]
            public async Task<IActionResult> UpdateStudnetsAsync(Guid id, Students students)
            {
                if (id != students.StudentId)
                {
                    return BadRequest();
                }

            Students dbstudent = await _projects.UpdateStudnetsAsync(students);

                if (dbstudent== null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"{students.Name} could not be updated");
                }

                return NoContent();
            }

            [HttpDelete("id")]
            public async Task<IActionResult> DeleteStudent(Guid id)
            {
                var student = await _projects.GetStudentAsync(id, false);
                (bool status, string message) = await _projects.DeleteStudentsAsync(student);

                if (status == false)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, message);
                }

                return StatusCode(StatusCodes.Status200OK, student);
            }
        }
    }

