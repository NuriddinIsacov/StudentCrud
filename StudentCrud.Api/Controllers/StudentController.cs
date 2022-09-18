using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCrud.App.DTOs;
using StudentCrud.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCrud.Api.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService _studentService)
        {
            studentService = _studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            return Ok(await studentService.GetAlAsync());
        }

        [HttpGet("id: int")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            return Ok(await studentService.GetStudentByIdAsync(id));
        }

        [HttpPost()]
        public async Task<IActionResult> CreateStudent(StudentForCreationDto studentDto)
        {
            return Created("", await studentService.CreateStudentAsync(studentDto));
        }

        [HttpPut("id: int")]
        public async Task<IActionResult> UpdateStudent(int id, StudentForCreationDto studentDto)
        {
            if (await studentService.UpdateStudentAsync(id, studentDto) is not null)
            {
                return Ok(await studentService.UpdateStudentAsync(id, studentDto));
            }
            else
                return NoContent();
        }

        [HttpDelete("id: int")]
        public async Task DeleteStudent(int id)
        {
            await studentService.DeleteStudent(id);
        }

        public async Task<IReadOnlyList<StudentDto>> GetSortedStudentsAsync()
        {
            return await studentService.GetSortedStudents();
        }

    }
}
