using Microsoft.EntityFrameworkCore;
using ProAtividade.Domain.Atividade.DTO;
using ProAtividade.Domain.Atividade.Services;
using ProAtividade.Domain.Atividade.Repositories;

namespace ProAtividade.Domain.Atividade.Services {
    public class AtividadeService : IAtividadeService {

        public IAtividadeRepository _atividadeRepository { get; }

        public AtividadeService(IAtividadeRepository atividadeRepository) {
            _atividadeRepository = atividadeRepository;
        }

        public async Task<IEnumerable<PegarAtividadeDTO>> ListarAtividades(AtividadeFiltroDTO filtro) {


            var query = QueryFiltrada(filtro);

            var atividade = query.Select(
                p => new PegarAtividadeDTO {
                    Id = p.Id,
                    Titulo = p.Titulo,
                    Descricao = p.Descricao,
                    Prioridade = p.Prioridade,
                    DataDeCriacao = p.DataCriacao.ToShortDateString(),
                    DataDeConclusao = p.DataConclusao == null ? "" : p.DataConclusao.ToString()
                }
            ).ToListAsync();

            return await atividade;
        }

        public async Task<PegarAtividadeDTO> AdicionarAtividade(AtividadeDTO atividade) {

            if (string.IsNullOrWhiteSpace(atividade.Titulo)) {
                throw new Exception("A atividade deve ter um título");
            }

            var NovaAtividade = new Atividade {
                Descricao = atividade.Descricao,
                Titulo = atividade.Titulo,
                Prioridade = atividade.Prioridade,
                DataCriacao = DateTime.Now
            };

            _atividadeRepository.Adicionar(NovaAtividade);

            var retorno = new PegarAtividadeDTO();

            if (await _atividadeRepository.SalvarMudancasAsync()) {
                retorno = new PegarAtividadeDTO {
                    Id = NovaAtividade.Id,
                    Titulo = NovaAtividade.Titulo,
                    Descricao = NovaAtividade.Descricao,
                    Prioridade = NovaAtividade.Prioridade,
                    DataDeCriacao = NovaAtividade.DataCriacao.ToShortDateString(),
                    DataDeConclusao = ""
                };

                return retorno;

            }

            return retorno;
        }

        public async Task<PegarAtividadeDTO> EditarAtividade(AtividadeDTO atividade) {

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

            var retorno = new PegarAtividadeDTO();

            if (await _atividadeRepository.SalvarMudancasAsync()) {
                retorno = new PegarAtividadeDTO {
                    Id = atividadeEditada.Id,
                    Titulo = atividadeEditada.Titulo,
                    Descricao = atividadeEditada.Descricao,
                    Prioridade = atividadeEditada.Prioridade,
                    DataDeCriacao = atividadeEditada.DataCriacao.ToShortDateString(),
                    DataDeConclusao = atividadeEditada.DataConclusao == null ? "" : atividadeEditada.DataConclusao.ToString()
                };

                return retorno;

            }

            return retorno;

        }

        public async Task DeletarTarefa(int? id) {

            if (id <= 0) {
                throw new Exception("A tarefa selecionada não existe ou já foi excluida");
            };

            var atividadeSelecionada = _atividadeRepository.Carregar(id);

            _atividadeRepository.Deletar(atividadeSelecionada);

            await _atividadeRepository.SalvarMudancasAsync();
        }

        public async Task ConcluirTarefa(int? id) {
            var atividadeSelecionada = _atividadeRepository.Carregar(id);
            atividadeSelecionada.ConcluirTarefa();

            await _atividadeRepository.SalvarMudancasAsync();
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
    }
}
