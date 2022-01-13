using ProAtividade.API.Domain.Atividade.DTO;

namespace ProAtividade.API.Services
{
    public interface IAtividadesService
    {
        Task<IEnumerable<AtividadeDTO>> ListarAtividades(AtividadeFiltroDTO filtro);
        Task<AtividadeDTO> AdicionarAtividade(AtividadeDTO atividade);
        Task<AtividadeDTO> EditarAtividade(AtividadeDTO atividade);
        Task DeletarTarefa(int? id);
    }
}