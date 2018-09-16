using System;

namespace Loki.Core.Domain.Entities
{
    public class PessoaJuridica
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
    }
}