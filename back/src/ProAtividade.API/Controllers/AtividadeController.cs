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
        public async Task<ActionResult<IAsyncEnumerable<AtividadeDTO>>> ListarAtividades(AtividadeFiltroDTO filtro) {
            try {

                var dados = await _atividadeService.ListarAtividades(filtro);
                return Ok(dados);

            } catch {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter lista de alunos");

            }
        }

        [HttpPost]
        public async Task<ActionResult<AtividadeDTO>> SalvarNovaAtividade(AtividadeDTO atividade) {
            try {
                 
                await _atividadeService.AdicionarAtividade(atividade);
                return Ok("A atividade foi adicionada com sucesso");                

            } catch {

                return BadRequest("Requisição inválida");
                
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AtividadeDTO>> EditarAtividade(int id, AtividadeDTO atividade) {
            try
            {
                 if (id == atividade.Id){
                     
                     await _atividadeService.EditarAtividade(atividade);
                     return Ok("A atividade foi removida com sucesso");

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