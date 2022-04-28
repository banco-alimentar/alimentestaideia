// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Federa��o Portuguesa dos Bancos Alimentares Contra a Fome">
// Copyright (c) Federa��o Portuguesa dos Bancos Alimentares Contra a Fome. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace BancoAlimentar.AlimentaEstaIdeia.Sas.Web.TenantManagement
{
    using System;
    using Azure.Extensions.AspNetCore.Configuration.Secrets;
    using Azure.Identity;
    using Azure.Security.KeyVault.Secrets;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Default class for the entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point for the web application.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        /// <summary>
        /// Create the host runtime.
        /// </summary>
        /// <param name="args">Entry point arguments.</param>
        /// <returns>A reference to the <see cref="IHostBuilder"/>.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            IHostBuilder builder = Host.CreateDefaultBuilder(args);
            builder
             .ConfigureAppConfiguration((context, config) =>
             {
                 var builtConfig = config.Build();
                 if (context.HostingEnvironment.IsProduction() || context.HostingEnvironment.IsStaging())
                 {
                     var secretClient = new SecretClient(
                         new Uri(builtConfig["VaultUri"], UriKind.Absolute),
                         new DefaultAzureCredential());
                     config.AddAzureKeyVault(
                         secretClient,
                         new AzureKeyVaultConfigurationOptions()
                         {
                             ReloadInterval = TimeSpan.FromDays(1),
                         });

                     builtConfig = config.Build();
                 }
             })
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();
             });

            return builder;
        }
    }
}