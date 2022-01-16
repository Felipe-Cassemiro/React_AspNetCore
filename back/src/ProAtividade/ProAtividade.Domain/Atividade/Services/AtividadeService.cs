
using Microsoft.EntityFrameworkCore;
using ProAtividade.Domain.Atividade.DTO;
using ProAtividade.Domain.Atividade.Repositories;

namespace ProAtividade.Domain.Atividade.Services {
    public class AtividadeService : IAtividadeService {

        public AtividadeRepository _atividadeRepository { get; }

        public AtividadeService(AtividadeRepository atividadeRepository) {
            _atividadeRepository = atividadeRepository;
        }

        public async Task<IEnumerable<AtividadeDTO>> ListarAtividades(AtividadeFiltroDTO filtro) {


            var query = QueryFiltrada(filtro);

            var atividade = query.Select(
                p => new AtividadeDTO {
                    Id = p.Id,
                    Titulo = p.Titulo,
                    Descricao = p.Descricao,
                    Prioridade = p.Prioridade
                }
            ).ToListAsync();

            return await atividade;
        }

        private IQueryable<Atividade> QueryFiltrada(AtividadeFiltroDTO filtro) {

            var query = _atividadeRepository.QueryAtividade();

            if (string.IsNullOrWhiteSpace(filtro.TextoDaPesquisa)) {
                return query;
            }

            if (filtro.PesquisarPor == PesquisarPorTituloOuDescricao.Titulo) {
                query = query.Where(p => p.Titulo.Contains(filtro.TextoDaPesquisa));
            }

            if (filtro.PesquisarPor == PesquisarPorTituloOuDescricao.Descricao) {
                query = query.Where(p => p.Titulo.Contains(filtro.TextoDaPesquisa));
            }

            query.AsNoTracking().OrderBy(p => p.Prioridade);

            return query;
        }

        public async Task<AtividadeDTO> AdicionarAtividade(AtividadeDTO atividade) {

            if (string.IsNullOrWhiteSpace(atividade.Titulo)) {
                throw new Exception("A atividade deve ter um título");
            }

            var query = _atividadeRepository.QueryAtividade();
            if (query.Where(p => p.Titulo == atividade.Titulo) != null) {
                throw new Exception("Já existe uma atividade com esse título");
            }

            var NovaAtividade = new Atividade {
                Descricao = atividade.Descricao,
                Titulo = atividade.Titulo,
                Prioridade = atividade.Prioridade
            };

            _atividadeRepository.Adicionar(NovaAtividade);

            await _atividadeRepository.SalvarMudancasAsync();

            atividade.Id = NovaAtividade.Id;

            return atividade;
        }

        public async Task DeletarTarefa(int? id) {

            if (id <= 0) {
                throw new Exception();
            };

            var query = _atividadeRepository.QueryAtividade();
            var atividadeSelecionada = query.Where(p => p.Id == id).First();

            _atividadeRepository.Deletar(atividadeSelecionada);

            await _atividadeRepository.SalvarMudancasAsync();
        }

        public async Task<AtividadeDTO> EditarAtividade(AtividadeDTO atividade) {

            if (string.IsNullOrWhiteSpace(atividade.Titulo) || atividade.Id <= 0) {
                throw new Exception();
            };

            var query = _atividadeRepository.QueryAtividade();
            var atividadeSelecionada = query.Where(p => p.Id == atividade.Id);

            var atividadeEditada = atividadeSelecionada
            .Select(p => new Atividade {
                Id = p.Id,
                Descricao = atividade.Descricao,
                Titulo = atividade.Titulo,
                Prioridade = atividade.Prioridade
            }).First();

            _atividadeRepository.Atualizar(atividadeEditada);
            await _atividadeRepository.SalvarMudancasAsync();

            var retorno = query
                .Select(p => new AtividadeDTO {
                    Id = p.Id,
                    Titulo = p.Titulo,
                    Descricao = p.Descricao,
                    Prioridade = p.Prioridade
                }).Where(p => p.Id == atividade.Id).First();

            return retorno;

        }
    }
}
