using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio.Models;
using WebAPI.Repository.Services.Interface;

namespace WebAPI.Repository.Services.Repository
{
    public class PacienteRepository : IPaciente
    {

        public readonly Context _context;

        public PacienteRepository(Context context)
        {
            _context = context;
        }

        public bool AdicionaPaciente(Paciente paciente)
        {
            if (paciente == null)
            {
                return false;
            }

            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return true;
        }

        public List<Paciente> RecuperarPacientes()
        {
            var pacientes = _context.Pacientes.ToList();

            return pacientes;
        }

        public Paciente RecuperaPacientePorId(int id)
        {
            var paciente = _context.Pacientes.Where(x => x.Id == id).FirstOrDefault();

            return paciente;
        }

        public bool AtualizaPaciente(int id, Paciente paciente)
        {
            var buscaPaciente = _context.Pacientes.Where(x => x.Id == id).FirstOrDefault();

            if (buscaPaciente == null)
            {
                return false;
            }

            var montaUpdate = MapperPacienteUpdate(buscaPaciente, paciente);
            _context.SaveChanges();
            return true;
        }

        public bool DeletaPaciente(int id)
        {
            var request = _context.Pacientes.Where(x => x.Id == id).FirstOrDefault();

            if (request == null)
                return false;

            _context.Remove(request);
            _context.SaveChanges();
            return true;
        }


        public Paciente MapperPacienteUpdate(Paciente pacienteBanco, Paciente pacienteRequest)
        {
            pacienteBanco.DataNascimento = pacienteRequest.DataNascimento;
            pacienteBanco.Endereco = pacienteRequest.Endereco;
            pacienteBanco.Nome = pacienteRequest.Nome;

            return pacienteBanco;
        }
    }
}
