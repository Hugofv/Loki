using System;
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
    }
}