using AluraChallenge1.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AluraChallenge1.Service.Interfaces
{
    public interface IVideoService : IBaseService<Video>
    {
        Task<List<Video>> SearchVideoAsync(string titulo);
    }
}
