using Microsoft.AspNetCore.Mvc;
using ProAtividade.API.Services;
using ProAtividade.API.Domain.Atividade.DTO;

namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        public IAtividadesService _atividadeService;

        public AtividadeController(IAtividadesService atividadeService) {
            
            _atividadeService = atividadeService;

        }
        
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<AtividadeDTO>>> ListarAtividades() {
            try {

                var dados = await _atividadeService.ListarAtividades();
                return Ok(dados);

            } catch {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter lista de alunos");

            }
        }

        [HttpPost("PesquisarAtividade")]
        public async Task<ActionResult<IAsyncEnumerable<AtividadeDTO>>> PesquisarAtividadePor([FromBody] AtividadeFiltroDTO filtro) {
            try {

                var dados = await _atividadeService.PesquisarAtividadePor(filtro);
                return Ok(dados);                

            } catch {

                return BadRequest("Requisição inválida");
                
            }
        }

        [HttpPost]
        public async Task<ActionResult<AtividadeDTO>> SalvarNovaAtividade([FromBody] AtividadeDTO atividade) {
            try {

                await _atividadeService.AdicionarAtividade(atividade);
                return Ok("A atividade foi adicionada com sucesso");

            }
            catch {

                return BadRequest("Requisição inválida");

            }
        }

        [HttpPut]
        public async Task<ActionResult<AtividadeDTO>> EditarAtividade([FromBody] AtividadeDTO atividade) {
            try
            {
                 if (atividade.Id.HasValue){
                     
                     await _atividadeService.EditarAtividade(atividade);
                     return Ok("A atividade foi editada com sucesso");

                 } else {

                     return NotFound($"Atividade não encontrado");
                 
                 }
            }
            catch
            {
                
                return NotFound($"Atividade Não encontrado");
                
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AtividadeDTO>> DeletarAtividade(int? id) {
            try {
                if(id > 0) {

                    await _atividadeService.DeletarTarefa(id);
                    
                    return Ok("A atividade foi removida com sucesso");

                } else {

                    return NotFound($"Atividade não encontrado");
                
                }

            } catch {

                return NotFound($"Atividade Não encontrado");

            }
        }
    }
}