using BookStore.ApplictaionDbContext;
using BookStore.Services.Interface.BaseService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.Services.Repository.BaseServiceRepositoy
{
    public class BaseServiceRepository<T> : IBaseService<T> where T : class
    {
        private readonly DataContext _context;

        public BaseServiceRepository(DataContext context)
        {
            _context = context;
        }

        public async void Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public async void AddRange(IEnumerable<T> entities)
        {
           await _context.Set<T>().AddRangeAsync(entities);
        }
        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();

        }
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

      
    }
}
