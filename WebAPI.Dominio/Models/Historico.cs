using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Dominio.Models
{
    public class Historico
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int ConsultaId { get; set; }
        public virtual Consulta Consulta { get; set; }
    }
}
