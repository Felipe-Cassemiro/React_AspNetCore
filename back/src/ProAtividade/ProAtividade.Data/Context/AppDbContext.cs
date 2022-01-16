using Microsoft.EntityFrameworkCore;
using ProAtividade.Domain.Atividade;

namespace ProAtividade.Data.Context {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Atividade> Atividade { get; set; }
    }
}
