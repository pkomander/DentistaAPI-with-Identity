using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio.Models;
using WebAPI.Repository.Services.Interface;

namespace WebAPI.Repository.Services.Repository
{
    public class AgendaRepository : IAgenda
    {
        public readonly Context _context;

        public AgendaRepository(Context context)
        {
            _context = context;
        }

        public bool AdicionaAgenda(Agenda agenda)
        {
            if (agenda == null)
                return false;

            _context.Agendas.Add(agenda);
            _context.SaveChanges();
            return true;
        }

        public List<Agenda> RecuperarAgenda()
        {
            var request = _context.Agendas.ToList();

            return request;
        }

        public Agenda RecuperaAgendaPorId(int id)
        {
            var request = _context.Agendas.Where(x => x.Id == id).FirstOrDefault();

            return request;
        }

        public bool AtualizaAgenda(int id, Agenda agenda)
        {
            var request = _context.Agendas.Where(x => x.Id == id).FirstOrDefault();

            if (request == null)
                return false;

            var montaUpdate = MapperAgendaUpdate(request, agenda);
            _context.SaveChanges();
            return true;
        }

        public bool DeletaAgenda(int id)
        {
            var request = _context.Agendas.Where(x => x.Id == id).FirstOrDefault();

            if (request == null) return false;

            _context.Agendas.Remove(request);
            _context.SaveChanges();
            return true;
        }

        public Agenda MapperAgendaUpdate(Agenda agendaBD, Agenda agendaUp)
        {
            agendaBD.DentistaId = agendaUp.DentistaId;
            agendaBD.Dentista = agendaUp.Dentista;
            agendaBD.Disponibilidade = agendaUp.Disponibilidade;

            return agendaBD;
        }
    }
}
