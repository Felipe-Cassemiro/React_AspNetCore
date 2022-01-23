using System.ComponentModel.DataAnnotations;

namespace ProAtividade.Domain.Atividade {
    public class Atividade {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Titulo { get; set; }

        [StringLength(200)]
        public string? Descricao { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }

        [Required]
        [Range(0, 3)]
        public PrioridadeEnum Prioridade { get; set; }

        public Atividade() {
            DataCriacao = DateTime.Now;
        }

        public void ConcluirTarefa() {
            if (DataConclusao == null) {
                DataConclusao = DateTime.Now;
            }
            else {
                throw new Exception($"Essa tarefa foi concluida em: {DataConclusao?.ToString("dd/MM/yyyy hh:mm")}");
            }
        }

    }
}
