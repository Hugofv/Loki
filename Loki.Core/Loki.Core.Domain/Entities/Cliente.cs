using System;

namespace Loki.Core.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        public string Nome { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
    }
}