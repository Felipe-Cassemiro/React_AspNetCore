using ProAtividade.Domain.Atividade.DTO;

namespace ProAtividade.Domain.Atividade.Services {
    public interface IAtividadeService {
        Task<IEnumerable<PegarAtividadeDTO>> ListarAtividades(AtividadeFiltroDTO filtro);
        Task<PegarAtividadeDTO> AdicionarAtividade(AtividadeDTO atividade);
        Task<PegarAtividadeDTO> EditarAtividade(AtividadeDTO atividade);
        Task DeletarTarefa(int? id);
        Task ConcluirTarefa(int? id);
    }
}
