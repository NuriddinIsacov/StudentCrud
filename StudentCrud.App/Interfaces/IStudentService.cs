using StudentCrud.App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.App.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> CreateStudentAsync(StudentForCreationDto studentDto);

        Task DeleteStudent(int id);

        Task<StudentDto> GetStudentByIdAsync(int id);

        Task<IReadOnlyList<StudentDto>> GetAlAsync();

        Task<StudentDto> UpdateStudentAsync(int id, StudentForCreationDto studentDto);
    }
}
