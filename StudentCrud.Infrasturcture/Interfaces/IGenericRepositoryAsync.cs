using StudentCrud.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.Infrasturcture.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T: class
    {
        Task<T> AddAsyn(T entity);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task Delete(int id);
    }
}
