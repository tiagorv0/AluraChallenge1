using AluraChallenge1.Infra;
using AluraChallenge1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using AluraChallenge1.Service.Interfaces;

namespace AluraChallenge1.Service
{
    public class VideoService : BaseService<Video>, IVideoService
    {
        private readonly Context _context;

        public VideoService(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Video>> SearchVideoAsync(string titulo)
        {
            return await _context.Videos.Where(v => v.Titulo.ToLower().Contains(titulo.ToLower()))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
