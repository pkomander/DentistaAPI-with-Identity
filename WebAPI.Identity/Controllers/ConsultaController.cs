using Microsoft.AspNetCore.Mvc;
using WebAPI.Dominio.Models;
using WebAPI.Identity.Dto.DtoDentista;
using WebAPI.Repository.Services.Interface;

namespace WebAPI.Identity.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ConsultaController : ControllerBase
    {
        public readonly IConsulta _consulta;

        public ConsultaController(IConsulta consulta)
        {
            _consulta = consulta;
        }

        [HttpPost]
        public IActionResult AdicionarConsulta([FromBody] ConsultaDto consultaDto)
        {
            Consulta consulta = new Consulta
            {
                Data = consultaDto.Data,
                Horario = consultaDto.Horario,
                DentistaId = consultaDto.DentistaId,
                Dentista = consultaDto.Dentista,
                PacienteId = consultaDto.PacienteId,
                Paciente = consultaDto.Paciente
            };

            var request = _consulta.AdicionaConsulta(consulta);

            if (request == false)
                return BadRequest();

            return Ok(request);
        }

        [HttpGet]
        public IActionResult RecuperarConsultas()
        {
            var request = _consulta.RecuperarConsulta();

            return Ok(request);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarConsultasPorId(int id)
        {
            var request = _consulta.RecuperaConsultaPorId(id);

            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarConsulta(int id, [FromBody] ConsultaDto consultaDto)
        {
            Consulta consulta = new Consulta
            {
                Data = consultaDto.Data,
                Horario = consultaDto.Horario,
                DentistaId = consultaDto.DentistaId,
                Dentista = consultaDto.Dentista,
                PacienteId = consultaDto.PacienteId,
                Paciente = consultaDto.Paciente
            };

            var request = _consulta.AtualizaConsulta(id, consulta);

            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarConsulta(int id)
        {
            var request = _consulta.DeletaConsulta(id);

            if (request == null)
                return NotFound();

            return Ok(request);
        }
    }
}
