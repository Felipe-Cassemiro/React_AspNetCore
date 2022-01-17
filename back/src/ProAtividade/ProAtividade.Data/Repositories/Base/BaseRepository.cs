using ProAtividade.Data.Context;
using ProAtividade.Domain.BaseDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAtividade.Data.Repositories.Base {
    public class BaseRepository : IBaseRepository {

        public AppDbContext _context { get; }

        public BaseRepository(AppDbContext context) {
            _context = context;
        }

        public void Adicionar<T>(T entity) where T : class {
            _context.AddAsync(entity);
        }

        public void Atualizar<T>(T entity) where T : class {
            _context.Update(entity);
        }

        public void Deletar<T>(T entity) where T : class {
            _context.Remove(entity);
        }

        public void DeletarVarios<T>(T entityArray) where T : class {
            _context.RemoveRange(entityArray);
        }

        public async Task<IQueryable<T>> Queryable<T>(T entity) where T : class {
            return await Queryable<T>(entity);
        }

        public async Task<bool> SalvarMudancasAsync() {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
