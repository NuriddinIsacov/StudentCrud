using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentCrud.App.DTOs;
using StudentCrud.App.Interfaces;
using StudentCrud.Domain.Models;
using StudentCrud.Infrasturcture;
using StudentCrud.Infrasturcture.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.App.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext context;

        private readonly IMapper mapper;

        private readonly IStudentRepositoryAsync studentRepositori;
       
        public StudentService(IMapper _mapper, IStudentRepositoryAsync _studentRepository, AppDbContext dbContext)
        {
            context = dbContext;

            studentRepositori = _studentRepository;

            mapper = _mapper;
        }
       
        

        public async virtual Task<StudentDto> CreateStudentAsync(StudentForCreationDto studentDto)
        {
            var student = mapper.Map<StudentEntity>(studentDto);

            return mapper.Map<StudentDto>(await studentRepositori.AddAsyn(student));
        }

        public async virtual Task DeleteStudent(int id)
        {
            await studentRepositori.Delete(id);
        }

        public async virtual Task<IReadOnlyList<StudentDto>> GetAlAsync()
        {
            return mapper.Map<IReadOnlyList<StudentDto>>(await studentRepositori.GetAllAsync());
            
        }

        public async virtual Task<StudentDto> GetStudentByIdAsync(int id)
        {
            return mapper.Map<StudentDto>(await studentRepositori.GetByIdAsync(id));
        }

        public async virtual Task<StudentDto> UpdateStudentAsync(int id, StudentForCreationDto studentDto)
        {
            if (studentDto is not null)
            {
                var getStudent = await context.Students.FirstOrDefaultAsync(p => p.Id == id);

                if (getStudent is not null)
                {
                    mapper.Map(studentDto, getStudent);
                    context.Students.Attach(getStudent);
                    context.Entry(getStudent).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return mapper.Map<StudentDto>(getStudent);
                }
                else
                    return null;
            }
            else
                return null;
        }
    }
}
