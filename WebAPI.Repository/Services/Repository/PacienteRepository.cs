using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dominio.Models;
using WebAPI.Repository.Services.Interface;

namespace WebAPI.Repository.Services.Repository
{
    public class PacienteRepository : IPaciente
    {

        public readonly Context _context;

        public PacienteRepository(Context context)
        {
            _context = context;
        }

        public bool AdicionaPaciente(Paciente paciente)
        {
            if (paciente == null)
            {
                return false;
            }

            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return true;
        }

        public List<Paciente> RecuperarPacientes()
        {
            var pacientes = _context.Pacientes.ToList();
            EnviaEmailMarcacao();

            return pacientes;
        }

        public Paciente RecuperaPacientePorId(int id)
        {
            var paciente = _context.Pacientes.Where(x => x.Id == id).FirstOrDefault();

            return paciente;
        }

        public bool AtualizaPaciente(int id, Paciente paciente)
        {
            var buscaPaciente = _context.Pacientes.Where(x => x.Id == id).FirstOrDefault();

            if (buscaPaciente == null)
            {
                return false;
            }

            var montaUpdate = MapperPacienteUpdate(buscaPaciente, paciente);
            _context.SaveChanges();
            return true;
        }

        public bool DeletaPaciente(int id)
        {
            var request = _context.Pacientes.Where(x => x.Id == id).FirstOrDefault();

            if (request == null)
                return false;

            _context.Remove(request);
            _context.SaveChanges();
            return true;
        }


        public Paciente MapperPacienteUpdate(Paciente pacienteBanco, Paciente pacienteRequest)
        {
            pacienteBanco.DataNascimento = pacienteRequest.DataNascimento;
            pacienteBanco.Endereco = pacienteRequest.Endereco;
            pacienteBanco.Nome = pacienteRequest.Nome;

            return pacienteBanco;
        }

        public void EnviaEmailMarcacao()
        {
            //string PacienteName, DateTime dataConsulta, string emailUsuario
            string siteName = "Dentista Agenda";
            string mensagem = "Consulta Agendada para {PacienteName} na data: {dataConsulta}";

            try
            {

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("aluracursospaulo@gmail.com", "ffqryyapedgywzuc");
                MailMessage mail = new MailMessage();
                mail.Sender = new MailAddress("aluracursospaulo@gmail.com", "Dentista APP");
                mail.From = new MailAddress("aluracursospaulo@gmail.com", "Dentista APP");
                mail.To.Add(new MailAddress("praraujo2010@hotmail.com", "Paciente"));
                mail.Subject = "Contato";
                mail.Body = $" Mensagem do site: {siteName} <br/> Nome: nomeUsuario. <br/> Email : emailUsuario <br/> Mensagem :  {mensagem}";
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                client.Send(mail);
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
