using AluraChallenge1.Infra;
using AluraChallenge1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AluraChallenge1.Service
{
    public class VideoService : IVideoService
    {
        private readonly Context _context;

        public VideoService(Context context)
        {
            _context = context;
        }

        public async Task<List<Video>> GetAllAsync()
        {
            return await _context
                .Set<Video>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Video> GetAsync(Guid id)
        {
            var obj = await GetAllAsync();
            return obj.Where(v => v.Id == id).FirstOrDefault();
        }

        public async Task RemoveAsync(Guid id)
        {
            var obj = await GetAsync(id);

            if(obj != null)
            {
                _context.Videos.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Video> CreateAsync(Video model)
        {
            _context.Videos.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Video> UpdateAsync(Video model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
