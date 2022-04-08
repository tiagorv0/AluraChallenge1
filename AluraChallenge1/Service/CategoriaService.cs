using AluraChallenge1.Infra;
using AluraChallenge1.Models;
using AluraChallenge1.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraChallenge1.Service
{
    public class CategoriaService : BaseService<Categoria>, ICategoriaService
    {
        private readonly Context _context;

        public CategoriaService(Context context) : base(context)
        {
            _context = context;
        }

        public List<Video> VideosPorCategoria(int id)
        {
            return _context.Categorias.SelectMany(v => v.Videos.Where(x => x.CategoriaId == id)).ToList();
        }
    }
}
