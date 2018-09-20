using System;
using Newtonsoft.Json;

namespace Loki.Core.Domain.Entities
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        [JsonProperty(PropertyName="data_nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}