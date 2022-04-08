using AluraChallenge1.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AluraChallenge1.Infra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>()
                .HasOne(video => video.Categoria)
                .WithMany(categoria => categoria.Videos)
                .HasForeignKey(v => v.CategoriaId);
        }
    }
}
