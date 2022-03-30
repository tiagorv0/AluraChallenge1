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

        public DbSet<Video> Videos { get; set; }
    }
}
