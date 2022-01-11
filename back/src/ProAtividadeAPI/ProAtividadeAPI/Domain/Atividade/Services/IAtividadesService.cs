using ProAtividade.API.Domain.Atividade.DTO;

namespace ProAtividade.API.Services
{
    public interface IAtividadesService
    {
        Task<IEnumerable<AtividadeDTO>> ListarAtividades();
        Task<IEnumerable<AtividadeDTO>> PesquisarAtividadePor(AtividadeFiltroDTO filtro);
        Task AdicionarAtividade(AtividadeDTO atividade);
        Task EditarAtividade(AtividadeDTO atividade);
        Task DeletarTarefa(int? id);
    }
}