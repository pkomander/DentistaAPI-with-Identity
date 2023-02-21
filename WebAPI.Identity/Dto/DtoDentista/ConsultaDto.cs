using WebAPI.Dominio.Models;

namespace WebAPI.Identity.Dto.DtoDentista
{
    public class ConsultaDto
    {
        public DateTime Data { get; set; }
        public string Horario { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int DentistaId { get; set; }
        public Dentista Dentista { get; set; }
    }
}
