using ProAtividade.API.Models;

namespace ProAtividade.API.Domain.Atividade.DTO
{
    public class AtividadeDTO
    {
        public int? Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public PrioridadeEnum Prioridade { get; set; }
    }
}