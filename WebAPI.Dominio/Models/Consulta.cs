using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Dominio.Models
{
    public class Consulta
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Horario { get; set; }
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public int DentistaId { get; set; }
        public virtual Dentista Dentista { get; set; }
    }
}
