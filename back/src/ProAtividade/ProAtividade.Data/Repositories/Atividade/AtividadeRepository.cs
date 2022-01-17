using ProAtividade.Data.Context;
using ProAtividade.Data.Repositories.Base;
using ProAtividade.Domain.Atividade;
using ProAtividade.Domain.Atividade.Repositories;

namespace ProAtividade.Data.Repositories {
    public class AtividadeRepository : BaseRepository, IAtividadeRepository {

        public AppDbContext _context { get; }
        public AtividadeRepository(AppDbContext context) : base(context) {
            _context = context;
        }


        public IQueryable<Atividade> QueryAtividade() {
            var query = _context.Atividade.AsQueryable();

            return query;
        }

    }
}
