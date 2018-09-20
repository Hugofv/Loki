using System;
using Newtonsoft.Json;

namespace Loki.Core.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        public string Nome { get; set; }
        [JsonProperty(PropertyName = "pessoa_fisica")]
        public PessoaFisica PessoaFisica { get; set; }
        [JsonProperty(PropertyName = "pessoa_juridica")]
        public PessoaJuridica PessoaJuridica { get; set; }
    }
}