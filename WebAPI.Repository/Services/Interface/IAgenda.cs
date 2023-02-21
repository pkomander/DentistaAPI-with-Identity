using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio.Models;

namespace WebAPI.Repository.Services.Interface
{
    public interface IAgenda
    {
        public List<Agenda> RecuperarAgenda();
        public Agenda RecuperaAgendaPorId(int id);
        public bool AdicionaAgenda(Agenda agenda);
        public bool AtualizaAgenda(int id, Agenda agenda);
        public bool DeletaAgenda(int id);
    }
}
