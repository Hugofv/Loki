namespace Loki.Core.Domain.Queries
{
    public class ClienteQuery
    {
        public static string Cria => @"
            INSERT INTO ""Cliente"" (""Nome"", ""PessoaFisicaId"", ""PessoaJuridicaId"") 
            VALUES (@Nome, @PessoaFisicaId, @PessoaJuridicaId)
        ";

        public static string Atualiza => @"
            UPDATE ""Cliente"" SET ""Nome"" = @Nome WHERE ""Uuid"" = @Uuid
        ";

        public static string Excluir => @"
            UPDATE ""Cliente"" SET ""Ativo"" = FALSE WHERE ""Uuid"" = @Uuid;
        ";

        public static string CriaPessoaFisica => @"
            INSERT INTO ""PessoaFisica"" (""Cpf"", ""DataNascimento"") 
            VALUES (@Cpf, @DataNascimento)
            RETURNING ""Id""
        ";

        public static string CriaPessoaJuridica => @"
            INSERT INTO ""PessoaJuridica"" (""Cnpj"", ""RazaoSocial"")
            VALUES (@Cnpj, @RazaoSocial)
            RETURNING ""Id""
        ";

        public static string AtualizaPessoaFisica => @"
            UPDATE ""PessoaFisica"" SET ""Cpf"" = @Cpf, ""DataNascimento"" = @DataNascimento WHERE ""Id"" = @PessoaFisicaId;
        ";

        public static string AtualizaPessoaJuridica => @"
            UPDATE ""PessoaJuridica"" SET ""Cnpj"" = @Cnpj, ""RazaoSocial"" = @RazaoSocial WHERE ""Id"" = @PessoaJuridicaId;
        ";

        public static string ExcluirPessoaFisica => @"
            UPDATE ""PessoaFisica"" pf SET ""Ativo"" = FALSE
            FROM ""Cliente"" cli WHERE cli.""PessoaFisicaId"" = pf.""Id""
            AND cli.""Uuid"" = @Uuid;
        ";

        public static string ExcluirPessoaJuridica => @"
            UPDATE ""PessoaJuridica"" pf SET ""Ativo"" = FALSE
            FROM ""Cliente"" cli WHERE cli.""PessoaJuridicaId"" = pf.""Id""
            AND cli.""Uuid"" = @Uuid;
        ";

        public static string Listar => @"
            SELECT
	            cli.""Id"",
	            cli.""Uuid"",
	            cli.""Nome"",
	            pf.""Id"",
	            pf.""Cpf"",
	            pf.""DataNascimento"",
	            pj.""Id"",
	            pj.""Cnpj"",
	            pj.""RazaoSocial""
            FROM ""Cliente"" cli
            LEFT JOIN ""PessoaFisica"" pf ON pf.""Id"" = cli.""PessoaFisicaId"" AND pf.""Ativo"" IS TRUE
            LEFT JOIN ""PessoaJuridica"" pj ON pj.""Id"" = cli.""PessoaJuridicaId"" AND pj.""Ativo"" IS TRUE
            WHERE cli.""Ativo"" IS TRUE;
        ";
    }
}