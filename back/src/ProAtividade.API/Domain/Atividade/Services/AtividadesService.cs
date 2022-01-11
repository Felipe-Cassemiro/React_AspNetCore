using ProAtividade.API.Context;
using ProAtividade.API.Domain.Atividade.DTO;
using Microsoft.EntityFrameworkCore;
using ProAtividade.API.Models.Entites;

namespace ProAtividade.API.Services
{
    public class AtividadesService : IAtividadesService
    {
        private readonly AppDbContext _context;

        public AtividadesService(AppDbContext context) {
            _context = context;
            
        }

        public async Task<IEnumerable<AtividadeDTO>> ListarAtividades(AtividadeFiltroDTO filtro){   
            
            
            var query = ObterQueryFiltrada(filtro);
            
            var atividade = query.Select(
                p => new AtividadeDTO {
                    Id = p.Id,
                    Titulo = p.Titulo,
                    Descricao = p.Descricao,
                    PrioridadeEnum = p.Prioridade
                }
            ).ToListAsync();

            return await atividade;
        }

        public async Task AdicionarAtividade(AtividadeDTO atividade){

            if(string.IsNullOrWhiteSpace(atividade.Titulo)){
                return;
            }

            var NovaAtividade = new Atividade{
                Descricao = atividade.Descricao,
                Titulo = atividade.Titulo,
                Prioridade = atividade.PrioridadeEnum
            };

            _context.Atividade.Add(NovaAtividade);
            
            await _context.SaveChangesAsync();
        }

        public async Task DeletarTarefa(int? id){
            
            var query = _context.Atividade.AsQueryable();
            var atividadeSelecionada = query.Where(p => p.Id == id).First();
            
            _context.Atividade.Remove(atividadeSelecionada);

            await _context.SaveChangesAsync();
        }

        public async Task EditarAtividade(AtividadeDTO atividade){
            
            if(string.IsNullOrWhiteSpace(atividade.Titulo)){
                return;
            }

            var query = _context.Atividade.AsQueryable();
            var atividadeSelecionada = query.Where(p => p.Id == atividade.Id);
            
            var atividadeEditada = atividadeSelecionada
            .Select(p => new Atividade {
                Descricao = atividade.Descricao,
                Titulo = atividade.Titulo,
                Prioridade = atividade.PrioridadeEnum
            }).First();

            _context.Entry(atividadeEditada).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        private IQueryable<Atividade> ObterQueryFiltrada(AtividadeFiltroDTO filtro)
        {
            var query = _context.Atividade.AsQueryable();
            
            if(string.IsNullOrWhiteSpace(filtro.Titulo)){
                query = query.Where(p => p.Titulo.Contains(filtro.Titulo));
            }

            if(string.IsNullOrWhiteSpace(filtro.Descricao)){
                query = query.Where(p => p.Titulo.Contains(filtro.Descricao));
            }

            return query;
        }

    }
}