using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAtividade.Domain.Atividade.DTO {
    public class PegarAtividadeDTO {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public PrioridadeEnum Prioridade { get; set; }
        public string DataDeCriacao { get; set; }
        public string? DataDeConclusao { get; set; }
    }
}
