using AluraChallenge1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AluraChallenge1.Service.Interfaces
{
    public interface IBaseService<T> where T : Base
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<bool> RemoveAsync(int id);
        Task<T> CreateAsync(T model);
        Task<T> UpdateAsync(T model);
    }
}
