using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Dominio.Models
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string NomeEspecialidade { get; set; }
        public string Descricao { get; set; }
    }
}
