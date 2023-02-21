using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio.Models;
using WebAPI.Repository.Services.Interface;

namespace WebAPI.Repository.Services.Repository
{
    public class HistoricoRepository : IHistorico
    {

        public readonly Context _context;

        public HistoricoRepository(Context context)
        {
            _context = context;
        }

        public bool AdicionaHistoricoConsulta(Historico historico)
        {
            if (historico == null)
                return false;

            _context.HistoricoConsultas.Add(historico);
            _context.SaveChanges();
            return true;
        }

        public List<Historico> RecuperarHistoricoConsultas()
        {
            var request = _context.HistoricoConsultas.ToList();

            return request;
        }

        public Historico RecuperaHistoricoConsultaPorId(int id)
        {
            var request = _context.HistoricoConsultas.Where(x => x.Id == id).FirstOrDefault();

            return request;
        }

        public bool AtualizaHistoricoConsulta(int id, Historico historico)
        {
            var request = _context.HistoricoConsultas.Where(x => x.Id == id).FirstOrDefault();

            if (request == null)
                return false;

            var montaUpdate = MapperHistoricoUpdate(request, historico);

            _context.SaveChanges();
            return true;
        }

        public bool DeletaConsulta(int id)
        {
            var request = _context.HistoricoConsultas.Where(x => x.Id == id).FirstOrDefault();

            if (request == null)
                return false;

            _context.HistoricoConsultas.Remove(request);
            _context.SaveChanges();
            return true;
        }

        public Historico MapperHistoricoUpdate(Historico historicoDB, Historico historicoUp)
        {
            historicoDB.Consulta = historicoUp.Consulta;
            historicoDB.ConsultaId = historicoUp.ConsultaId;

            return historicoDB;
        }
    }
}
