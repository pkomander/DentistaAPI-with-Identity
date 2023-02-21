using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Dominio.Models
{
    public class Agenda
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int DentistaId { get; set; }
        public virtual Dentista Dentista { get; set; }
        public string Disponibilidade { get; set; }
    }
}
