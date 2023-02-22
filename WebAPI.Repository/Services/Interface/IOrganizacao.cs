using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio;
using WebAPI.Dominio.Models;

namespace WebAPI.Repository.Services.Interface
{
    public interface IOrganizacao
    {
        public List<Organizacao> RecuperarOrganizacoes();
        public Organizacao RecuperaOrganizacaoPorId(int id);
        public bool AdicionaOrganizacao(Organizacao organizacao, IFormFile ImagemOrganizacao);
        public bool AtualizaOrganizacao(int id, Organizacao organizacao);
        public bool DeletaOrganizacao(int id);
        public bool InativaOrganizacao(int id);
    }
}
