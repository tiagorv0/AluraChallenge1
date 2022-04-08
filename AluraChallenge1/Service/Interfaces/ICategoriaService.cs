using AluraChallenge1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AluraChallenge1.Service.Interfaces
{
    public interface ICategoriaService : IBaseService<Categoria>
    {
        List<Video> VideosPorCategoria(int id);
    }
}
