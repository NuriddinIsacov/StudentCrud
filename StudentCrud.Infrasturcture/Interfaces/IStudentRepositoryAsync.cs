using StudentCrud.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.Infrasturcture.Interfaces
{
    public interface IStudentRepositoryAsync : IGenericRepositoryAsync<StudentEntity>
    {
         Task<IReadOnlyList<StudentEntity>> GetSortedStudentByName();

    }
}
