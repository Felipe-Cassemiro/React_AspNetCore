using Microsoft.EntityFrameworkCore;
using ProAtividade.API.Models.Entites;

namespace ProAtividade.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Atividade> Atividade { get; set; }
    }
}