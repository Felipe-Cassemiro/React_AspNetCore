using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAtividade.Domain.Atividade.Services {
    public class AtividadeService : IAtividadeService{
        //private readonly AppDbContext _context;

        //        public AtividadesService(AppDbContext context) {
        //            _context = context;

        //        }

        //        public async Task<IEnumerable<AtividadeDTO>> ListarAtividades(AtividadeFiltroDTO filtro) {


        //            var query = QueryFiltrada(filtro);

        //            var atividade = query.Select(
        //                p => new AtividadeDTO {
        //                    Id = p.Id,
        //                    Titulo = p.Titulo,
        //                    Descricao = p.Descricao,
        //                    Prioridade = p.Prioridade
        //                }
        //            ).ToListAsync();

        //            return await atividade;
        //        }

        //        private IQueryable<Atividade> QueryFiltrada(AtividadeFiltroDTO filtro) {
        //            var query = _context.Atividade.AsQueryable();

        //            if (string.IsNullOrWhiteSpace(filtro.TextoDaPesquisa)) {
        //                return query;
        //            }

        //            if (filtro.PesquisarPor == PesquisarPorTituloOuDescricao.Titulo) {
        //                query = query.Where(p => p.Titulo.Contains(filtro.TextoDaPesquisa));
        //            }

        //            if (filtro.PesquisarPor == PesquisarPorTituloOuDescricao.Descricao) {
        //                query = query.Where(p => p.Titulo.Contains(filtro.TextoDaPesquisa));
        //            }

        //            return query;
        //        }

        //        public async Task<AtividadeDTO> AdicionarAtividade(AtividadeDTO atividade){

        //            if(string.IsNullOrWhiteSpace(atividade.Titulo)){
        //                throw new Exception("A atividade deve ter um t�tulo");
        //            }

        //            var NovaAtividade = new Atividade{
        //                Descricao = atividade.Descricao,
        //                Titulo = atividade.Titulo,
        //                Prioridade = atividade.Prioridade
        //            };

        //            _context.Atividade.Add(NovaAtividade);

        //            await _context.SaveChangesAsync();

        //            atividade.Id = NovaAtividade.Id;

        //            return atividade;
        //        }

        //        public async Task DeletarTarefa(int? id){

        //            if (id <= 0) {
        //                throw new Exception();
        //            };

        //            var query = _context.Atividade.AsQueryable();
        //            var atividadeSelecionada = query.Where(p => p.Id == id).First();

        //            _context.Atividade.Remove(atividadeSelecionada);

        //            await _context.SaveChangesAsync();
        //        }

        //        public async Task<AtividadeDTO> EditarAtividade(AtividadeDTO atividade){

        //            if(string.IsNullOrWhiteSpace(atividade.Titulo) || atividade.Id <= 0) {
        //                throw new Exception();
        //            };

        //            var query = _context.Atividade.AsQueryable();
        //            var atividadeSelecionada = query.Where(p => p.Id == atividade.Id);

        //            var atividadeEditada = atividadeSelecionada
        //            .Select(p => new Atividade {
        //                Id = p.Id,
        //                Descricao = atividade.Descricao,
        //                Titulo = atividade.Titulo,
        //                Prioridade = atividade.Prioridade
        //            }).First();

        //            _context.Entry(atividadeEditada).State = EntityState.Modified;
        //            await _context.SaveChangesAsync();

        //            var retorno = query
        //                .Select(p => new AtividadeDTO {
        //                    Id = p.Id,
        //                    Titulo = p.Titulo,
        //                    Descricao = p.Descricao,
        //                    Prioridade = p.Prioridade
        //                }).Where(p => p.Id == atividade.Id).First();

        //            return retorno;

        //        }
    }
}
