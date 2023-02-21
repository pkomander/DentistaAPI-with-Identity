using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dominio.Models;
using WebAPI.Identity.Dto.DtoDentista;
using WebAPI.Repository.Services.Interface;

namespace WebAPI.Identity.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PacientesController : ControllerBase
    {

        public readonly IPaciente _paciente;

        public PacientesController(IPaciente paciente)
        {
            _paciente = paciente;
        }


        [HttpPost]
        public IActionResult AdicionarPaciente([FromBody] PacienteDto pacienteDto)
        {
            Paciente paciente = new Paciente
            {
                Nome = pacienteDto.Nome,
                DataNascimento = pacienteDto.DataNascimento,
                Endereco = pacienteDto.Endereco,
                Bairro = pacienteDto.Bairro,
                Cidade = pacienteDto.Cidade,
                CPF = pacienteDto.CPF,
                DDD = pacienteDto.DDD,
                Email = pacienteDto.Email,
                Estado = pacienteDto.Estado,
                Telefone = pacienteDto.Telefone
            };
            var adicionaPaciente = _paciente.AdicionaPaciente(paciente);

            if (adicionaPaciente == false)
            {
                return BadRequest();
            }
            return Ok(paciente);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RecuperaPacientes()
        {
            var recuperaPaciente = _paciente.RecuperarPacientes();

            return Ok(recuperaPaciente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPacientePorId(int id)
        {
            var buscaPaciente = _paciente.RecuperaPacientePorId(id);

            if (buscaPaciente == null)
            {
                return NotFound();
            }

            return Ok(buscaPaciente);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaPaciente(int id, [FromBody] PacienteDto pacienteDto)
        {
            Paciente paciente = new Paciente
            {
                Nome = pacienteDto.Nome,
                DataNascimento = pacienteDto.DataNascimento,
                Endereco = pacienteDto.Endereco
            };

            var response = _paciente.AtualizaPaciente(id, paciente);

            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaPaciente(int id)
        {
            var request = _paciente.DeletaPaciente(id);

            if (request == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}