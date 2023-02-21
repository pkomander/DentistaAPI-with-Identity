using Microsoft.AspNetCore.Mvc;
using WebAPI.Dominio.Models;
using WebAPI.Identity.Dto.DtoDentista;
using WebAPI.Repository.Services.Interface;

namespace WebAPI.Identity.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DentistaController : ControllerBase
    {
        public readonly IDentista _dentista;

        public DentistaController(IDentista dentista)
        {
            _dentista = dentista;
        }

        [HttpPost]
        public IActionResult AdicionaDentista([FromBody] DentistaDto dentistaDto)
        {
            Dentista dentista = new Dentista
            {
                Nome = dentistaDto.Nome,
                Especialidade = dentistaDto.Especialidade,
                HorariosDisponiveis = dentistaDto.HorariosDisponiveis
            };

            var request = _dentista.AdicionaDentista(dentista);

            if (request == false)
                return BadRequest();

            return Ok(dentista);
        }

        [HttpGet]
        public IActionResult RecuperaDentistas()
        {
            var request = _dentista.RecuperarDentistas();
            return Ok(request);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaDentistaPorId(int id)
        {
            var request = _dentista.RecuperaDentistaPorId(id);

            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaDentista(int id, [FromBody] DentistaDto dentistaDto)
        {
            Dentista dentista = new Dentista
            {
                Nome = dentistaDto.Nome,
                Especialidade = dentistaDto.Especialidade,
                HorariosDisponiveis = dentistaDto.HorariosDisponiveis
            };

            var request = _dentista.AtualizaDentista(id, dentista);

            if (request == false)
                return NotFound();

            return Ok(request);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaDentista(int id)
        {
            var request = _dentista.DeletaDentista(id);

            if (request == false)
                return NotFound();

            return Ok(request);
        }
    }
}
