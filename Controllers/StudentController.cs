using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET All Student data
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();

            return Ok(students);
        }
 

        // POST All Student data 
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            var createdStudent = await _studentService.AddStudentAsync(student);

            return Ok(new
            {
                message = "Student added successfully",
                data = createdStudent
            });
        }

        // Update All Student data
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            var updatedStudent = await _studentService.UpdateStudentAsync(id, student);

            if (updatedStudent == null)
            {
                return NotFound(new
                {
                    message = "Student not found"
                });
            }

            return Ok(new
            {
                message = "Student updated successfully",
                data = updatedStudent
            });
        }

        // DELETE: api/student/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudentAsync(id);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Student not found"
                });
            }

            return Ok(new
            {
                message = "Student deleted successfully"
            });
        }
    }
}