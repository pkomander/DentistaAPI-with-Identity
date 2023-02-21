using WebAPI.Dominio.Models;

namespace WebAPI.Identity.Dto.DtoDentista
{
    public class HistoricoDto
    {
        public int ConsultaId { get; set; }
        public virtual Consulta Consulta { get; set; }
    }
}
