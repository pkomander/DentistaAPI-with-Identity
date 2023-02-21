using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Dominio.Models
{
    public class Dentista
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string HorariosDisponiveis { get; set; }
    }
}
