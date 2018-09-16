using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Loki.Core.Api
{
    /// <inheritdoc />
    public class Program
    {
        private static readonly string Url = Environment.GetEnvironmentVariable("KESTREL_HOSTNAME") ?? "http://127.0.0.1:5000";

        /// <inheritdoc />
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseUrls(Url)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
