using System.ComponentModel.DataAnnotations;
using WebAPI.Dominio.Models;

namespace WebAPI.Identity.Dto
{
    public class OrganizacaoDto
    {
        [Required(ErrorMessage = "O campo DentistaId e obrigatorio")]
        public string Name { get; set; }

        //inserindo campos necessarios para o consultorio
        //[Required(ErrorMessage = "O campo DentistaId e obrigatorio")]
        //public int DentistaId { get; set; }
        //public Dentista Dentista { get; set; }
        [Required(ErrorMessage = "O campo Endereco e obrigatorio")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "O campo Estado e obrigatorio")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "O campo Cidade e obrigatorio")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "O campo DDD e obrigatorio")]
        public string DDD { get; set; }
        [Required(ErrorMessage = "O campo Numero e obrigatorio")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "O campo CNPJ e obrigatorio")]
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "O campo CEP e obrigatorio")]
        public string CEP { get; set; }
        [Required(ErrorMessage = "O campo Ativo e obrigatorio")]
        public bool Ativo { get; set; }

        //aqui devera ser o campo do Dto
        public IFormFile Imagem { get; set; }
    }
}
