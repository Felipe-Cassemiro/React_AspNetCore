using ProAtividade.API.Models;

namespace ProAtividade.API.Domain.Atividade.DTO
{
    public class AtividadeFiltroDTO
    {
        public string? TextoDaPesquisa { get; set; }
        public PesquisarPorTituloOuDescricao PesquisarPor { get; set; }
    }

    public enum PesquisarPorTituloOuDescricao {
        Titulo = 0,
        Descricao = 1,
    }
}