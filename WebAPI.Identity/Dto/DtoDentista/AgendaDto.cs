using WebAPI.Dominio.Models;

namespace WebAPI.Identity.Dto.DtoDentista
{
    public class AgendaDto
    {
        public int DentistaId { get; set; }
        public virtual Dentista Dentista { get; set; }
        public string Disponibilidade { get; set; }
    }
}
