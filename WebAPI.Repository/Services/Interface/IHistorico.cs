using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio.Models;

namespace WebAPI.Repository.Services.Interface
{
    public interface IHistorico
    {
        public List<Historico> RecuperarHistoricoConsultas();
        public Historico RecuperaHistoricoConsultaPorId(int id);
        public bool AdicionaHistoricoConsulta(Historico consulta);
        public bool AtualizaHistoricoConsulta(int id, Historico consulta);
        public bool DeletaConsulta(int id);
    }
}
