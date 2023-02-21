using Microsoft.AspNetCore.Mvc;
using WebAPI.Dominio.Models;
using WebAPI.Identity.Dto.DtoDentista;
using WebAPI.Repository.Services.Interface;

namespace WebAPI.Identity.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AgendaController : ControllerBase
    {
        public readonly IAgenda _agenda;

        public AgendaController(IAgenda agenda)
        {
            _agenda = agenda;
        }

        [HttpPost]
        public IActionResult AdicionaAgenda([FromBody] AgendaDto agendaDto)
        {
            Agenda agenda = new Agenda
            {
                DentistaId = agendaDto.DentistaId,
                Dentista = agendaDto.Dentista,
                Disponibilidade = agendaDto.Disponibilidade
            };

            var request = _agenda.AdicionaAgenda(agenda);

            if (request == false)
                return BadRequest();

            return Ok(request);
        }

        [HttpGet]
        public IActionResult RecuperaAgendas()
        {
            var request = _agenda.RecuperarAgenda();

            return Ok(request);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaAgendasPorId(int id)
        {
            var request = _agenda.RecuperaAgendaPorId(id);

            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaAgenda(int id, [FromBody] AgendaDto agendaDto)
        {
            Agenda agenda = new Agenda
            {
                DentistaId = agendaDto.DentistaId,
                Dentista = agendaDto.Dentista,
                Disponibilidade = agendaDto.Disponibilidade
            };

            var request = _agenda.AtualizaAgenda(id, agenda);

            if (request == false)
                return NotFound();

            return Ok(request);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarAgenda(int id)
        {
            var request = _agenda.DeletaAgenda(id);

            if (request == false)
                return NotFound();

            return Ok(request);
        }
    }
}
