using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio.Models;
using WebAPI.Repository.Services.Interface;

namespace WebAPI.Repository.Services.Repository
{
    public class ConsultaRepository : IConsulta
    {

        public readonly Context _context;

        public ConsultaRepository(Context context)
        {
            _context = context;
        }

        public bool AdicionaConsulta(Consulta consulta)
        {
            if (consulta == null)
                return false;

            _context.Consultas.Add(consulta);
            _context.SaveChanges();
            return true;
        }

        public List<Consulta> RecuperarConsulta()
        {
            var request = _context.Consultas.ToList();
            return request;
        }

        public Consulta RecuperaConsultaPorId(int id)
        {
            var request = _context.Consultas.Where(x => x.Id == id).FirstOrDefault();

            return request;
        }

        public bool AtualizaConsulta(int id, Consulta consulta)
        {
            var request = _context.Consultas.Where(x => x.Id == id).FirstOrDefault();

            if (request == null)
                return false;

            var montaUpdate = MapperConsultaUpdate(request, consulta);

            _context.SaveChanges();
            return true;
        }

        public bool DeletaConsulta(int id)
        {
            var request = _context.Consultas.Where(x => x.Id == id).FirstOrDefault();

            if (request == null) return false;

            _context.Consultas.Remove(request);
            _context.SaveChanges();
            return true;
        }

        public Consulta MapperConsultaUpdate(Consulta consultaDB, Consulta consultaUp)
        {
            consultaDB.Data = consultaUp.Data;
            consultaDB.Dentista = consultaUp.Dentista;
            consultaDB.Paciente = consultaUp.Paciente;
            consultaDB.Horario = consultaUp.Horario;
            consultaDB.PacienteId = consultaUp.PacienteId;
            consultaDB.DentistaId = consultaUp.DentistaId;

            return consultaDB;
        }
    }
}
