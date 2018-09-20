using System;
using System.Collections.Generic;
using Loki.Core.Api.Controllers;
using Loki.Core.Application.Interfaces;
using Loki.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Loki.Core.Api.Test.Controllers
{
    public class ClienteControllerTest
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
        public void Criar__ClienteValido__RetornaCreatedResult()
        {
            // Prepara
            var mock = new Mock<IClienteService>();
            mock.Setup(clienteService => clienteService.Criar(_cliente)).Returns(true);

            // Testa
            var controller = new ClienteController(mock.Object);
            var retorno = controller.Criar(_cliente);

            //Valida
            Assert.IsAssignableFrom<CreatedResult>(retorno);
        }

        [Fact]
        public void Criar__ClienteInvalido__RetornaBadRequestResult()
        {
            // Prepara
            var mock = new Mock<IClienteService>();
            mock.Setup(clienteService => clienteService.Criar(null)).Returns(false);

            // Testa
            var controller = new ClienteController(mock.Object);
            var retorno = controller.Criar(null);

            //Valida
            Assert.IsAssignableFrom<BadRequestResult>(retorno);
        }

        [Fact]
        public void Criar__ErroServidor__RetornaBadRequestResult()
        {
            // Prepara
            var mock = new Mock<IClienteService>();
            mock.Setup(clienteService => clienteService.Criar(null)).Throws<Exception>();

            // Testa
            var controller = new ClienteController(mock.Object);
            var retorno = controller.Criar(null);

            //Valida
            Assert.IsAssignableFrom<BadRequestResult>(retorno);
        }

        [Fact]
        public void Atualizar__ClienteValido__RetornaOkResult()
        {
            // Prepara
            var mock = new Mock<IClienteService>();
            mock.Setup(clienteService => clienteService.Atualizar(_cliente, It.IsAny<Guid>())).Returns(true);

            // Testa
            var controller = new ClienteController(mock.Object);
            var retorno = controller.Atualizar(_cliente, It.IsAny<Guid>());

            //Valida
            Assert.IsAssignableFrom<OkResult>(retorno);
        }

        [Fact]
        public void Atualizar__ClienteInvalido__RetornaNotFoundResult()
        {
            // Prepara
            var mock = new Mock<IClienteService>();
            mock.Setup(clienteService => clienteService.Atualizar(null, Guid.Empty)).Returns(false);

            // Testa
            var controller = new ClienteController(mock.Object);
            var retorno = controller.Atualizar(null, Guid.Empty);

            //Valida
            Assert.IsAssignableFrom<NotFoundResult>(retorno);
        }

        [Fact]
        public void Atualizar__ErroServidor__RetornaBadRequestResult()
        {
            // Prepara
            var mock = new Mock<IClienteService>();
            mock.Setup(clienteService => clienteService.Atualizar(null, Guid.Empty)).Throws<Exception>();

            // Testa
            var controller = new ClienteController(mock.Object);
            var retorno = controller.Atualizar(null, Guid.Empty);

            //Valida
            Assert.IsAssignableFrom<BadRequestResult>(retorno);
        }

        [Fact]
        public void Excluir__ClienteValido__RetornaOkResult()
        {
            // Prepara
            var mock = new Mock<IClienteService>();
            mock.Setup(clienteService => clienteService.Excluir(It.IsAny<Guid>())).Returns(true);

            // Testa
            var controller = new ClienteController(mock.Object);
            var retorno = controller.Excluir(It.IsAny<Guid>());

            //Valida
            Assert.IsAssignableFrom<OkResult>(retorno);
        }

        [Fact]
        public void Excluir__ClienteInvalido__RetornaNotFoundResult()
        {
            // Prepara
            var mock = new Mock<IClienteService>();
            mock.Setup(clienteService => clienteService.Excluir(Guid.Empty)).Returns(false);

            // Testa
            var controller = new ClienteController(mock.Object);
            var retorno = controller.Excluir(Guid.Empty);

            //Valida
            Assert.IsAssignableFrom<NotFoundResult>(retorno);
        }

        [Fact]
        public void Excluir__ErroServidor__RetornaBadRequestResult()
        {
            // Prepara
            var mock = new Mock<IClienteService>();
            mock.Setup(clienteService => clienteService.Excluir(Guid.Empty)).Throws<Exception>();

            // Testa
            var controller = new ClienteController(mock.Object);
            var retorno = controller.Excluir(Guid.Empty);

            //Valida
            Assert.IsAssignableFrom<BadRequestResult>(retorno);
        }

        [Fact]
        public void Listar__ClientesValido__RetornaObjectResult()
        {
            // Prepara
            var mock = new Mock<IClienteService>();
            mock.Setup(clienteService => clienteService.Listar()).Returns(new List<Cliente>
            {
                _cliente,
                _cliente
            });

            // Testa
            var controller = new ClienteController(mock.Object);
            var retorno = controller.Listar();

            //Valida
            Assert.IsAssignableFrom<ObjectResult>(retorno);
        }

        [Fact]
        public void Listar__ClientesInvalido__RetornaNoContentResult()
        {
            // Prepara
            var mock = new Mock<IClienteService>();
            mock.Setup(clienteService => clienteService.Listar()).Returns(new List<Cliente>());

            // Testa
            var controller = new ClienteController(mock.Object);
            var retorno = controller.Listar();

            //Valida
            Assert.IsAssignableFrom<NoContentResult>(retorno);
        }

        [Fact]
        public void Listar__ErroServidor__RetornaBadRequestResult()
        {
            // Prepara
            var mock = new Mock<IClienteService>();
            mock.Setup(clienteService => clienteService.Listar()).Throws<Exception>();

            // Testa
            var controller = new ClienteController(mock.Object);
            var retorno = controller.Listar();

            //Valida
            Assert.IsAssignableFrom<BadRequestResult>(retorno);
        }
    }
}
