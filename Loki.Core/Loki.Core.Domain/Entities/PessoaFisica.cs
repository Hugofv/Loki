using System;

namespace Loki.Core.Domain.Entities
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}