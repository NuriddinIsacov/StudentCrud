using Microsoft.EntityFrameworkCore;
using StudentCrud.Infrasturcture.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.Infrasturcture.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly AppDbContext dbContext;

        public GenericRepositoryAsync(AppDbContext context)
        {
            dbContext = context;
        }

        public async virtual Task<T> AddAsyn(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async virtual Task Delete(int id)
        {
            var entity = await dbContext.Set<T>().FindAsync(id);

            dbContext.Set<T>().Remove(entity);

            await dbContext.SaveChangesAsync();
        }

        public async virtual Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async virtual Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }
    }
}
