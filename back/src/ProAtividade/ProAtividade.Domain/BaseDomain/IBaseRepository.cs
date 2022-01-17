using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAtividade.Domain.BaseDomain {
    public interface IBaseRepository {
        void Adicionar<T>(T entity) where T : class;
        void Atualizar<T>(T entity) where T : class;
        void Deletar<T>(T entity) where T : class;
        void DeletarVarios<T>(T entity) where T : class;
        Task<IQueryable<T>> Queryable<T>(T entity) where T : class;
        Task<bool> SalvarMudancasAsync();

    }
}
