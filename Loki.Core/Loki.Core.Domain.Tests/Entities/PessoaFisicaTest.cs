using System;
using Loki.Core.Domain.Entities;
using Xunit;

namespace Loki.Core.Domain.Tests.Entities
{
    public class PessoaFisicaTest
    {
        private readonly PessoaFisica _pessoaFisica;

        public PessoaFisicaTest()
        {
            _pessoaFisica = new PessoaFisica();
        }

        [Fact]
        public void Id__AtribuiELeValor__DeveTerGetSet()
        {
            // Prepara e Testa
            const int id = 10;
            _pessoaFisica.Id = id;

            // Testa e Asserta
            Assert.True(_pessoaFisica.Id == id, "Id deve ter Get e Set");
        }

        [Fact]
        public void Cpf__AtribuiELeValor__DeveTerGetSet()
        {
            // Prepara e Testa
            const string cpf = "000.000.000-00";
            _pessoaFisica.Cpf = cpf;

            // Testa e Asserta
            Assert.True(_pessoaFisica.Cpf == cpf, "Cpf deve ter Get e Set");
        }

        [Fact]
        public void DataNascimento__AtribuiELeValor__DeveTerGetSet()
        {
            // Prepara e Testa
            var data = new DateTime(2018, 02, 02);
            _pessoaFisica.DataNascimento = data;

            // Testa e Asserta
            Assert.True(_pessoaFisica.DataNascimento == data, "Data Nascimento deve ter Get e Set");
        }
    }
}