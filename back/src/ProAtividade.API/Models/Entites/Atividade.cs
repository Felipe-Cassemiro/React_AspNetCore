using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAtividade.API.Models.Entites
{
    public class Atividade
    {
        // [Key]
        public int Id { get; set; }

        // [Required]
        // [StringLength(60)]
        // public string Titulo { get; set; }

        // [Required]
        // [StringLength(200)]
        // public string Descricao { get; set; }

        // [Required]
        // [Range(0,3)]
        // public PrioridadeEnu Prioridade { get; set; }
    }
}