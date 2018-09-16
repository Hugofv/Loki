using System;

namespace Loki.Core.Domain.Constantes
{
    public class Config
    {
        private static readonly string DataBaseServer = Environment.GetEnvironmentVariable("POSTGRES_HOSTNAME") ?? "";
        private static readonly string DataBaseUsername = Environment.GetEnvironmentVariable("POSTGRES_USERNAME") ?? "";
        private static readonly string DataBasePassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "";
        private static readonly string DataBaseDatabase = Environment.GetEnvironmentVariable("POSTGRES_DATABASE") ?? "";
        private static readonly string DataBasePort = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432";

        public static readonly string Conexao = $"Server={DataBaseServer};Port={DataBasePort};Database={DataBaseDatabase};User Id={DataBaseUsername};Password={DataBasePassword};";
    }
}