using System;
using Loki.Core.Domain.Entities;
using Xunit;

namespace Loki.Core.Domain.Tests.Entities
{
    public class ClienteTest
    {
        private readonly Cliente _cliente;

        public ClienteTest()
        {
            _cliente = new Cliente();
        }

        [Fact]
        public void Id__AtribuiELeValor__DeveTerGetSet()
        {
            // Prepara e Testa
            const int id = 10;
            _cliente.Id = id;

            // Testa e Asserta
            Assert.True(_cliente.Id == id, "Id deve ter Get e Set");
        }

        [Fact]
        public void Uuid__AtribuiELeValor__DeveTerGetSet()
        {
            // Prepara e Testa
            var uuid = Guid.NewGuid();
            _cliente.Uuid = uuid;

            // Testa e Asserta
            Assert.True(_cliente.Uuid == uuid, "Uuid deve ter Get e Set");
        }

        [Fact]
        public void Nome__AtribuiELeValor__DeveTerGetSet()
        {
            // Prepara e Testa
            const string nome = "Nome";
            _cliente.Nome = nome;

            // Testa e Asserta
            Assert.True(_cliente.Nome == nome, "Nome deve ter Get e Set");
        }

        [Fact]
        public void PessoaFisica__AtribuiELeValor__DeveTerGetSet()
        {
            // Prepara e Testa
            var pessoaFisica = new PessoaFisica
            {
                Cpf = "000.000.000-00",
                DataNascimento = new DateTime(2018, 02, 03)
            };
            _cliente.PessoaFisica = pessoaFisica;

            // Testa e Asserta
            Assert.True(_cliente.PessoaFisica == pessoaFisica, "Pessoa Fisica deve ter Get e Set");
        }

        [Fact]
        public void PessoaJuridica__AtribuiELeValor__DeveTerGetSet()
        {
            // Prepara e Testa
            var pessoaJuridica = new PessoaJuridica
            {
                Cnpj = "00.000.0000/0000-00",
                RazaoSocial = "Razão Social"
            };
            _cliente.PessoaJuridica = pessoaJuridica;

            // Testa e Asserta
            Assert.True(_cliente.PessoaJuridica == pessoaJuridica, "Pessoa Juridica deve ter Get e Set");
        }
    }
}