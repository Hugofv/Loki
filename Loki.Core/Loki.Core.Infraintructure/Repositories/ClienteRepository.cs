using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Loki.Core.Domain.Constantes;
using Loki.Core.Domain.Entities;
using Loki.Core.Domain.Interfaces;
using Loki.Core.Domain.Queries;
using Npgsql;

namespace Loki.Core.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _conexao;

        public ClienteRepository()
        {
            _conexao = Config.Conexao;
        }

        public bool Criar(Cliente cliente)
        {
            using (var conexao = new NpgsqlConnection(_conexao))
            {
                conexao.Open();
                using (var transacao = conexao.BeginTransaction())
                {
                    int? fisicaId = null, juridicaId = null;

                    if (cliente.PessoaFisica != null)
                    {
                        fisicaId = conexao.Query<int>(ClienteQuery.CriaPessoaFisica, new
                        {
                            cliente.PessoaFisica.Cpf,
                            cliente.PessoaFisica.DataNascimento
                        }).FirstOrDefault();
                    }

                    if (cliente.PessoaJuridica != null)
                    {
                        juridicaId = conexao.Query<int>(ClienteQuery.CriaPessoaJuridica, new
                        {
                            cliente.PessoaJuridica.Cnpj,
                            cliente.PessoaJuridica.RazaoSocial
                        }).FirstOrDefault();
                    }

                    var inserir = conexao.Execute(ClienteQuery.Cria, new
                    {
                        cliente.Nome,
                        PessoaFisicaId = fisicaId,
                        PessoaJuridicaId = juridicaId
                    });

                    if (inserir > 0)
                    {
                        transacao.Commit();
                        return true;
                    }

                    transacao.Rollback();
                    return false;
                }
            }
        }

        public bool Atualizar(Cliente cliente, Guid uuid)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(Guid uuid)
        {
            throw new NotImplementedException();
        }

        public IList<Cliente> Listar()
        {
            throw new NotImplementedException();
        }
    }
}