using System;
using System.Linq;
using Loki.Core.Application.Interfaces;
using Loki.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Loki.Core.Api.Controllers
{
    /// <inheritdoc/>
    [Route("api/cliente")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        /// <inheritdoc/>
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        /// <summary>
        /// Cria um novo Cliente
        /// </summary>
        /// <param name="cliente"> Json do cliente a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Criar([FromBody] Cliente cliente)
        {
            try
            {
                if (_clienteService.Criar(cliente))
                {
                    return new CreatedResult(string.Empty, null);
                }
                return new BadRequestResult();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new BadRequestResult();
            }
        }

        /// <summary>
        /// Atualiza as informações do cliente ja cadastrado
        /// </summary>
        /// <param name="cliente">Json do cliente a ser atualizado</param>
        /// <param name="uuid">Uuid do cliente a ser atualizado</param>
        /// <returns></returns>
        [HttpPut("{uuid}")]
        public IActionResult Atualizar([FromBody] Cliente cliente, Guid uuid)
        {
            try
            {
                if (_clienteService.Atualizar(cliente, uuid))
                {
                    return new OkResult();
                }
                return new NotFoundResult();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new BadRequestResult();
            }
        }

        /// <summary>
        /// Exclui o cliente
        /// </summary>
        /// <param name="uuid">Uuid do cliente a ser excluido do sistema</param>
        /// <returns></returns>
        [HttpDelete("{uuid}")]
        public IActionResult Excluir(Guid uuid)
        {
            try
            {
                if (_clienteService.Excluir(uuid))
                {
                    return new OkResult();
                }
                return new NotFoundResult();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new BadRequestResult();
            }
        }

        /// <summary>
        /// Busca todos os clientes cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var resultado = _clienteService.Listar();
                if (resultado.Any())
                {
                    return new ObjectResult(resultado);
                }
                return new NoContentResult();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new BadRequestResult();
            }
        }
    }
}