using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio.Models;

namespace WebAPI.Repository.Services.Interface
{
    public interface IDentista
    {
        public List<Dentista> RecuperarDentistas();
        public Dentista RecuperaDentistaPorId(int id);
        public bool AdicionaDentista(Dentista dentista);
        public bool AtualizaDentista(int id, Dentista dentista);
        public bool DeletaDentista(int id);
    }
}
