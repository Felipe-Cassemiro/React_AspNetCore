using Microsoft.AspNetCore.Mvc;
using ProAtividade.Domain.Atividade.DTO;
using ProAtividade.Domain.Atividade.Services;

namespace ProAtividade.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase {

        public IAtividadeService _atividadeService;

        public AtividadeController(IAtividadeService atividadeService) {

            _atividadeService = atividadeService;

        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<AtividadeDTO>>> ListarAtividades([FromQuery] AtividadeFiltroDTO filtro) {
            try {

                var dados = await _atividadeService.ListarAtividades(filtro);
                return Ok(dados);

            }
            catch {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter lista de alunos");

            }
        }

        [HttpPost]
        public async Task<ActionResult<AtividadeDTO>> SalvarNovaAtividade([FromBody] AtividadeDTO atividade) {
            try {

                var atividadeAdicionada = await _atividadeService.AdicionarAtividade(atividade);
                return atividadeAdicionada;

            }
            catch {

                return BadRequest("Requisição inválida");

            }
        }

        [HttpPut]
        public async Task<ActionResult<AtividadeDTO>> EditarAtividade([FromBody] AtividadeDTO atividade) {
            try {
                if (atividade.Id.HasValue) {

                    await _atividadeService.EditarAtividade(atividade);
                    return atividade;

                }
                else {

                    return NotFound($"Atividade não encontrado");

                }
            }
            catch {

                return NotFound($"Atividade Não encontrado");

            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarAtividade(int? id) {
            try {
                if (id > 0) {

                    await _atividadeService.DeletarTarefa(id);

                    return Ok("A atividade foi removida com sucesso");

                }
                else {

                    return NotFound($"Atividade não encontrado");

                }

            }
            catch {

                return NotFound($"Atividade Não encontrado");

            }
        }
    }
}
