using System.ComponentModel.DataAnnotations;
namespace ProAtividade.API.Models.Entites
{
    public class Atividade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Titulo { get; set; }

        [StringLength(200)]
        public string? Descricao { get; set; }

        [Required]
        [Range(0,3)]
        public PrioridadeEnum Prioridade { get; set; }
    }
}