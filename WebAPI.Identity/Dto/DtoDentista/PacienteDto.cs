﻿namespace WebAPI.Identity.Dto.DtoDentista
{
    public class PacienteDto
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
