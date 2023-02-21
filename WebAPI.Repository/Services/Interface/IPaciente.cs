using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio.Models;

namespace WebAPI.Repository.Services.Interface
{
    public interface IPaciente
    {
        public List<Paciente> RecuperarPacientes();
        public Paciente RecuperaPacientePorId(int id);
        public bool AdicionaPaciente(Paciente paciente);
        public bool AtualizaPaciente(int id, Paciente paciente);
        public bool DeletaPaciente(int id);
    }
}
