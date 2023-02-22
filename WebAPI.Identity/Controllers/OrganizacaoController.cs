using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dominio;
using WebAPI.Identity.Dto;
using WebAPI.Repository.Services.Interface;

namespace WebAPI.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizacaoController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public readonly IOrganizacao _organizacao;
        public OrganizacaoController(IWebHostEnvironment environment, IOrganizacao organizacao)
        {
            _environment = environment;
            _organizacao = organizacao;
        }

        [HttpPost]
        public IActionResult CriarOrganizacao([FromForm] OrganizacaoDto dto)
        {
            Organizacao organizacao = new Organizacao
            {
                Ativo= dto.Ativo,
                CEP = dto.CEP,
                Cidade = dto.Cidade,
                CNPJ = dto.CNPJ,
                DDD = dto.DDD,
                Endereco = dto.Endereco,
                Estado = dto.Estado,
                Name = dto.Name,
                Numero = dto.Numero
            };

            var nomeUnicoArquivo = _organizacao.AdicionaOrganizacao(organizacao, dto.Imagem);

            if (nomeUnicoArquivo == false)
                return BadRequest();

            return Ok(nomeUnicoArquivo);
        }

        [HttpGet]
        public IActionResult RecuperarOrganizacoes()
        {
            var busca = _organizacao.RecuperarOrganizacoes();

            return Ok(busca);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarOrganizacoes(int id)
        {
            var busca = _organizacao.RecuperaOrganizacaoPorId(id);

            return Ok(busca);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaOrganizacao(int id, [FromBody] OrganizacaoDto dto)
        {
            Organizacao organizacao = new Organizacao
            {
                Ativo = dto.Ativo,
                CEP = dto.CEP,
                Cidade = dto.Cidade,
                CNPJ = dto.CNPJ,
                DDD = dto.DDD,
                Endereco = dto.Endereco,
                Estado = dto.Estado,
                Name = dto.Name,
                Numero = dto.Numero
            };
            var busca = _organizacao.AtualizaOrganizacao(id, organizacao);

            if (busca == false)
                return NotFound();

            return Ok(busca);
        }

        [HttpPut("inativaOrganizacao/{id}")]
        public IActionResult InativaOrganizacao(int id)
        {
            var busca = _organizacao.DeletaOrganizacao(id);

            if (busca == false)
                return NotFound();

            return Ok(busca);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaOrganizacao(int id)
        {
            var busca = _organizacao.DeletaOrganizacao(id);

            if (busca == false)
                return NotFound();

            return Ok(busca);
        }
    }
}
