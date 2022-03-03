using Microsoft.EntityFrameworkCore;
using StudentCrud.Domain.Models;
using StudentCrud.Infrasturcture.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.Infrasturcture.Repositories
{
    public class StudentRepositoryAsync : GenericRepositoryAsync<StudentEntity>, IStudentRepositoryAsync
    {
        private readonly DbSet<StudentEntity> student;

        public StudentRepositoryAsync(AppDbContext context): base(context)
        {
            student = context.Set<StudentEntity>();

        }

    }
}
