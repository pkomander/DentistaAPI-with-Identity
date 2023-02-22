using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio;
using WebAPI.Dominio.Models;
using WebAPI.Repository.Services.Interface;

namespace WebAPI.Repository.Services.Repository
{
    public class OrganizacaoRepository : IOrganizacao
    {
        public readonly Context _context;

        public OrganizacaoRepository(Context context)
        {
            _context = context;
        }

        public bool AdicionaOrganizacao(Organizacao organizacao, IFormFile ImagemOrganizacao)
        {
            //Adicionando o caminho da imagem da logo no objeto
            organizacao.Imagem = SaveFile(ImagemOrganizacao);
            if (organizacao == null)
            {
                return false;
            }

            _context.Organizacoes.Add(organizacao);
            _context.SaveChanges();
            return true;
        }

        public List<Organizacao> RecuperarOrganizacoes()
        {
            var organizacoes = _context.Organizacoes.ToList();
            return organizacoes;
        }

        public Organizacao RecuperaOrganizacaoPorId(int id)
        {
            var organizacao = _context.Organizacoes.Where(x => x.Id == id).FirstOrDefault();
            return organizacao;
        }

        public bool AtualizaOrganizacao(int id, Organizacao organizacao)
        {
            var buscaOrganizacao = _context.Organizacoes.Where(x => x.Id == id).FirstOrDefault();

            if (organizacao == null)
            {
                return false;
            }

            //TODO - Deve ser criado o metodo Mapper para consumir o Dto
            //var montaUpdate = MapperPacienteUpdate(buscaPaciente, paciente);
            _context.SaveChanges();
            return true;
        }

        public bool DeletaOrganizacao(int id)
        {
            var buscaOrganizacao = _context.Organizacoes.Where(x => x.Id == id).FirstOrDefault();

            if (buscaOrganizacao == null)
                return false;

            _context.Remove(buscaOrganizacao);
            _context.SaveChanges();
            return true;
        }

        private string SaveFile(IFormFile file)
        {
            // Crie um diretório onde o arquivo será salvo
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Gere um nome de arquivo exclusivo para evitar conflitos
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Combine o caminho completo do arquivo
            var filePath = Path.Combine(directory, fileName);

            // Salve o arquivo no disco
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // Retorna o caminho completo do arquivo
            return filePath;
        }

        public bool InativaOrganizacao(int id)
        {
            var buscaOrganizacao = _context.Organizacoes.Where(x => x.Id == id).FirstOrDefault();

            if(buscaOrganizacao.Ativo == true)
            {
                buscaOrganizacao.Ativo = false;
            }
            else
            {
                buscaOrganizacao.Ativo = true;
            }

            _context.SaveChanges();
            return true;
        }
    }
}
