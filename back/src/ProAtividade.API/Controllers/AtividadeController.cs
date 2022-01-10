using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAtividade.API.Models.Entites;

namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        [HttpGet]
        public Atividade ListarAtividades() {
            return new Atividade();
        }

        [HttpGet("{id}")]
        public string ObterAtividade(int id) {
            return $"Minha atividade por id {id}";
        }

        [HttpPost]
        public Atividade SalvarNovaAtividade(Atividade atividade) {
            atividade.Id = 1;
            return atividade;
        }

        [HttpPut("{id}")]
        public Atividade EditarAtividade(Atividade atividade) {
            atividade.Id = atividade.Id + 1;
            return atividade;
        }

        [HttpDelete("{id}")]
        public string DeletarAtividade(int id) {
            return "Deletar atividade";
        }
    }
}