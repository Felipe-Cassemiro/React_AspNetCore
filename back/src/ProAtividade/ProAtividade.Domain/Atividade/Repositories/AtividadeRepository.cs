using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProAtividade.Data.Context;
using ProAtividade.Domain.Base;

namespace ProAtividade.Domain.Atividade.Repositories {
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