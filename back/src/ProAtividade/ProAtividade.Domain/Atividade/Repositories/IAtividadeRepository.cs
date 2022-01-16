using ProAtividade.Domain.Base;

namespace ProAtividade.Domain.Atividade.Repositories {
    public interface IAtividadeRepository : IBaseRepository {
        IQueryable<Atividade> QueryAtividade();
    }
}