using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio.Models;

namespace WebAPI.Repository.Services.Interface
{
    public interface IConsulta
    {
        public List<Consulta> RecuperarConsulta();
        public Consulta RecuperaConsultaPorId(int id);
        public bool AdicionaConsulta(Consulta consulta);
        public bool AtualizaConsulta(int id, Consulta consulta);
        public bool DeletaConsulta(int id);
    }
}
