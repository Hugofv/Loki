namespace Loki.Core.Domain.Queries
{
    public class ClienteQuery
    {
        public static string Cria => @"
            INSERT INTO ""Cliente"" (""Nome"", ""PessoaFisicaId"", ""PessoaJuridicaId"") 
            VALUES (@Nome, @PessoaFisicaId, @PessoaJuridicaId)
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
    }
}