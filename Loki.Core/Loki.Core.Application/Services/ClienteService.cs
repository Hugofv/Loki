using System;
using System.Collections.Generic;
using Loki.Core.Application.Interfaces;
using Loki.Core.Domain.Entities;
using Loki.Core.Domain.Interfaces;

namespace Loki.Core.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool Criar(Cliente cliente)
        {
            return _clienteRepository.Criar(cliente);
        }

        public bool Atualizar(Cliente cliente, Guid uuid)
        {
            return _clienteRepository.Atualizar(cliente, uuid);
        }

        public bool Excluir(Guid uuid)
        {
            return _clienteRepository.Excluir(uuid);
        }

        public IList<Cliente> Listar()
        {
            return _clienteRepository.Listar();
        }
    }
}