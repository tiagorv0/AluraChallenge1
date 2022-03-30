using AluraChallenge1.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AluraChallenge1.Service
{
    public interface IVideoService
    {
        Task<Video> GetAsync(Guid id);
        Task<List<Video>> GetAllAsync();
        Task RemoveAsync(Guid id);
        Task<Video> CreateAsync(Video model); 
        Task<Video> UpdateAsync(Video model);
    }
}
