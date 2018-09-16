using System;
using System.Collections.Generic;
using Loki.Core.Domain.Entities;

namespace Loki.Core.Domain.Interfaces
{
    public interface IClienteRepository
    {
        bool Criar(Cliente cliente);
        bool Atualizar(Cliente cliente, Guid uuid);
        bool Excluir(Guid uuid);
        IList<Cliente> Listar();
    }
}