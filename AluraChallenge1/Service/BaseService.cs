using AluraChallenge1.Infra;
using AluraChallenge1.Models;
using AluraChallenge1.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraChallenge1.Service
{
    public class BaseService<T> : IBaseService<T> where T : Base
    {
        private readonly Context _context;

        public BaseService(Context context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context
                .Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            var obj = await GetAllAsync();
            return obj.Where(v => v.Id == id).FirstOrDefault();
        }

        public virtual async Task<bool> RemoveAsync(int id)
        {
            var obj = await GetAsync(id);

            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public virtual async Task<T> CreateAsync(T model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public virtual async Task<T> UpdateAsync(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
