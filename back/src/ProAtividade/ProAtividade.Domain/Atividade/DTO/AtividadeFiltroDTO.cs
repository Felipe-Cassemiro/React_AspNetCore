using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAtividade.Domain.Atividade.DTO {
    public class AtividadeFiltroDTO {
        public string? TextoDaPesquisa { get; set; }
        public PesquisarPorTituloOuDescricao PesquisarPor { get; set; }
    }
    public enum PesquisarPorTituloOuDescricao {
        Titulo = 0,
        Descricao = 1,
    }
}
