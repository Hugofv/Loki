using Loki.Core.Domain.Entities;
using Xunit;

namespace Loki.Core.Domain.Tests.Entities
{
    public class PessoaJuridicaTest
    {
        private readonly PessoaJuridica _pessoaJuridica;

        public PessoaJuridicaTest()
        {
            _pessoaJuridica = new PessoaJuridica();
        }

        [Fact]
        public void Id__AtribuiELeValor__DeveTerGetSet()
        {
            // Prepara e Testa
            const int id = 10;
            _pessoaJuridica.Id = id;

            // Testa e Asserta
            Assert.True(_pessoaJuridica.Id == id, "Id deve ter Get e Set");
        }

        [Fact]
        public void Cnpj__AtribuiELeValor__DeveTerGetSet()
        {
            // Prepara e Testa
            const string cnpj = "00.000.0000/0000-00";
            _pessoaJuridica.Cnpj = cnpj;

            // Testa e Asserta
            Assert.True(_pessoaJuridica.Cnpj == cnpj, "Cnpj deve ter Get e Set");
        }

        [Fact]
        public void RazaoSocial__AtribuiELeValor__DeveTerGetSet()
        {
            // Prepara e Testa
            const string razao = "Razão Social";
            _pessoaJuridica.RazaoSocial = razao;

            // Testa e Asserta
            Assert.True(_pessoaJuridica.RazaoSocial == razao, "Razao Social deve ter Get e Set");
        }
    }
}