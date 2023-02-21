using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio.Models;
using WebAPI.Repository.Services.Interface;

namespace WebAPI.Repository.Services.Repository
{
    public class DentistaRepository : IDentista
    {

        public readonly Context _context;

        public DentistaRepository(Context context)
        {
            _context = context;
        }

        public bool AdicionaDentista(Dentista dentista)
        {
            if (dentista == null)
                return false;
            _context.Dentistas.Add(dentista);
            _context.SaveChanges();
            return true;
        }

        public List<Dentista> RecuperarDentistas()
        {
            var request = _context.Dentistas.ToList();

            return request;
        }

        public Dentista RecuperaDentistaPorId(int id)
        {
            var request = _context.Dentistas.Where(x => x.Id == id).FirstOrDefault();

            return request;
        }

        public bool AtualizaDentista(int id, Dentista dentista)
        {
            var request = _context.Dentistas.Where(x => x.Id == id).FirstOrDefault();

            if (request == null)
                return false;

            var montaUpdate = MapperDentistaUpdate(request, dentista);
            _context.SaveChanges();
            return true;
        }

        public bool DeletaDentista(int id)
        {
            var request = _context.Dentistas.Where(x => x.Id == id).FirstOrDefault();

            if (request == null)
                return false;

            _context.Remove(request);
            _context.SaveChanges();
            return true;
        }

        public Dentista MapperDentistaUpdate(Dentista dentistaBanco, Dentista dentistaRequest)
        {
            dentistaBanco.HorariosDisponiveis = dentistaRequest.HorariosDisponiveis;
            dentistaBanco.Especialidade = dentistaRequest.HorariosDisponiveis;
            dentistaBanco.Nome = dentistaRequest.HorariosDisponiveis;

            return dentistaBanco;
        }
    }
}
