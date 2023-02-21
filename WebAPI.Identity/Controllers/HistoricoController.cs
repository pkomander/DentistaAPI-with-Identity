using Microsoft.AspNetCore.Mvc;
using WebAPI.Dominio.Models;
using WebAPI.Identity.Dto.DtoDentista;
using WebAPI.Repository.Services.Interface;

namespace WebAPI.Identity.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HistoricoController : ControllerBase
    {
        public readonly IHistorico _historico;

        public HistoricoController(IHistorico historico)
        {
            _historico = historico;
        }

        [HttpPost]
        public IActionResult AdicionarHistorico([FromBody] HistoricoDto historicoDto)
        {
            Historico historico = new Historico
            {
                ConsultaId = historicoDto.ConsultaId,
                Consulta = historicoDto.Consulta
            };

            var request = _historico.AdicionaHistoricoConsulta(historico);

            if (request == false)
                return BadRequest();

            return Ok(request);
        }

        [HttpGet]
        public IActionResult RecuperarHistoricos()
        {
            var request = _historico.RecuperarHistoricoConsultas();

            return Ok(request);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarHistoricosPorId(int id)
        {
            var request = _historico.RecuperaHistoricoConsultaPorId(id);

            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarHistorico(int id, [FromBody] HistoricoDto historicoDto)
        {
            Historico historico = new Historico
            {
                ConsultaId = historicoDto.ConsultaId,
                Consulta = historicoDto.Consulta
            };

            var request = _historico.AtualizaHistoricoConsulta(id, historico);

            if (request == false)
                return NotFound();

            return Ok(request);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarHistoricoConsulta(int id)
        {
            var request = _historico.DeletaConsulta(id);

            if (request == false)
                return NotFound();

            return Ok(request);
        }
    }
}
