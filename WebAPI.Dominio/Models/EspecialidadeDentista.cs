using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Dominio.Models
{
    public class EspecialidadeDentista
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int DentistaId { get; set; }
        public virtual Dentista Dentista { get; set; }
        public int EspecialidadeId { get; set; }
        public virtual Especialidade Especialidade { get; set; }
    }
}
