using System;
using Newtonsoft.Json;

namespace Loki.Core.Domain.Entities
{
    public class PessoaJuridica
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        [JsonProperty(PropertyName = "razao_social")]
        public string RazaoSocial { get; set; }
    }
}