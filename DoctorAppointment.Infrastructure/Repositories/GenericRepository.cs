using DoctorAppointment.Core.Domain.Entities;
using DoctorAppointment.Core.Domain.RepositoryContracts;
using DoctorAppointment.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Infrastructure.Repositories
{
    public class GenericRepository<T> : Core.Domain.RepositoryContracts.IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await Save();
                return true;
            }
            catch
            {
                // Log the error here
                return false;
            }

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await Save();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            if (entity != null)
            {
                _dbSet.Update(entity);
                await Save();
                return true;
            }
            return false;
            
        }
    }
}
