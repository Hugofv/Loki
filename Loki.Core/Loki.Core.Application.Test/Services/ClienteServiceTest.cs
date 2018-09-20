using System;
using System.Collections.Generic;
using Loki.Core.Application.Services;
using Loki.Core.Domain.Entities;
using Loki.Core.Domain.Interfaces;
using Moq;
using Xunit;

namespace Loki.Core.Application.Test.Services
{
    public class ClienteServiceTest
    {
        private readonly Cliente _cliente = new Cliente
        {
            Nome = "Nome",
            PessoaFisica = new PessoaFisica
            {
                Cpf = "000.000.000-00",
                DataNascimento = new DateTime(2018, 01, 01)
            }
        };

        [Fact]
        public void Criar__ClienteValido__RetornaTrue()
        {
            // Prepara
            var mock = new Mock<IClienteRepository>();
            mock.Setup(clienteRepository => clienteRepository.Criar(_cliente)).Returns(true);

            // Testa
            var service = new ClienteService(mock.Object);
            var retorno = service.Criar(_cliente);

            //Valida
            Assert.True(retorno);
        }

        [Fact]
        public void Criar__ClienteInvalido__RetornaFalse()
        {
            // Prepara
            var mock = new Mock<IClienteRepository>();
            mock.Setup(clienteRepository => clienteRepository.Criar(null)).Returns(false);

            // Testa
            var service = new ClienteService(mock.Object);
            var retorno = service.Criar(_cliente);

            //Valida
            Assert.False(retorno);
        }

        [Fact]
        public void Atualizar__ClienteValido__RetornaTrue()
        {
            // Prepara
            var mock = new Mock<IClienteRepository>();
            mock.Setup(clienteRepository => clienteRepository.Atualizar(_cliente, It.IsAny<Guid>())).Returns(true);

            // Testa
            var service = new ClienteService(mock.Object);
            var retorno = service.Atualizar(_cliente, It.IsAny<Guid>());

            //Valida
            Assert.True(retorno);
        }

        [Fact]
        public void Atualizar__ClienteInvalido__RetornaFalse()
        {
            // Prepara
            var mock = new Mock<IClienteRepository>();
            mock.Setup(clienteRepository => clienteRepository.Atualizar(null, Guid.Empty)).Returns(false);

            // Testa
            var service = new ClienteService(mock.Object);
            var retorno = service.Atualizar(null, Guid.Empty);

            //Valida
            Assert.False(retorno);
        }

        [Fact]
        public void Excluir__ClienteValido__RetornaTrue()
        {
            // Prepara
            var mock = new Mock<IClienteRepository>();
            mock.Setup(clienteRepository => clienteRepository.Excluir(It.IsAny<Guid>())).Returns(true);

            // Testa
            var service = new ClienteService(mock.Object);
            var retorno = service.Excluir(It.IsAny<Guid>());

            //Valida
            Assert.True(retorno);
        }

        [Fact]
        public void Excluir__ClienteInvalido__RetornaFalse()
        {
            // Prepara
            var mock = new Mock<IClienteRepository>();
            mock.Setup(clienteRepository => clienteRepository.Excluir(Guid.Empty)).Returns(false);

            // Testa
            var service = new ClienteService(mock.Object);
            var retorno = service.Excluir(Guid.Empty);

            //Valida
            Assert.False(retorno);
        }

        [Fact]
        public void Listar__ClientesValidos__RetornaListaDeClientes()
        {
            // Prepara
            var mock = new Mock<IClienteRepository>();
            mock.Setup(clienteRepository => clienteRepository.Listar()).Returns(new List<Cliente>
            {
                _cliente,
                _cliente
            });

            // Testa
            var service = new ClienteService(mock.Object);
            var retorno = service.Listar();

            //Valida
            Assert.IsType<List<Cliente>>(retorno);
        }
    }
}