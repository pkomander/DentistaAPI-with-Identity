using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio.Models;

namespace WebAPI.Dominio
{
    public class Organizacao
    {
        [Key]
        [Required]
        public int Id { get; set; }
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

        //inserindo imagem na API
        public string Imagem { get; set; }
        //public int OrganizacaoDentistaId { get; set; }
        //public OrganizacaoDentista OrganizacaoDentista { get; set; }
    }
}
