using ProAtividade.Domain.BaseDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAtividade.Domain.Atividade.Repositories {
    public interface IAtividadeRepository : IBaseRepository {
        IQueryable<Atividade> QueryAtividade();
    }
}