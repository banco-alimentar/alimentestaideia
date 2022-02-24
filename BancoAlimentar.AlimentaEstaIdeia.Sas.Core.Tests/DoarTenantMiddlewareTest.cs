﻿// -----------------------------------------------------------------------
// <copyright file="DoarTenantMiddlewareTest.cs" company="Federação Portuguesa dos Bancos Alimentares Contra a Fome">
// Copyright (c) Federação Portuguesa dos Bancos Alimentares Contra a Fome. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace BancoAlimentar.AlimentaEstaIdeia.Sas.Core.Tests
{
    using BancoAlimentar.AlimentaEstaIdeia.Sas.ConfigurationProvider;
    using BancoAlimentar.AlimentaEstaIdeia.Sas.Core.Middleware;
    using BancoAlimentar.AlimentaEstaIdeia.Sas.Core.Tenant;
    using BancoAlimentar.AlimentaEstaIdeia.Sas.Core.Tenant.Naming;
    using BancoAlimentar.AlimentaEstaIdeia.Sas.Model;
    using BancoAlimentar.AlimentaEstaIdeia.Sas.Repository;
    using Microsoft.ApplicationInsights;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    /// <summary>
    /// Doar middleware test.
    /// </summary>
    public class DoarTenantMiddlewareTest : IClassFixture<ServicesFixture>
    {
        private readonly ServicesFixture fixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoarTenantMiddlewareTest"/> class.
        /// </summary>
        /// <param name="servicesFixture">Service list.</param>
        public DoarTenantMiddlewareTest(ServicesFixture servicesFixture)
        {
            this.fixture = servicesFixture;
        }

        /// <summary>
        /// Test subdomain naming strategy.
        /// </summary>
        [Fact]
        public async Task GetDoarTenantMiddlewareTest()
        {
            string baseDomain = "localhost";

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>() { { "SAS-BaseDomain", baseDomain } });

            IReadOnlyCollection<INamingStrategy> providers =
                new List<INamingStrategy>() {
                    new DomainNamingStrategy(),
                    new SubdomainNamingStrategy(builder.Build()),
                    new PathNamingStrategy() };

            var context = new DefaultHttpContext();
            context.Request.Scheme = "https";
            context.Request.Host = new HostString($"localhost", 44301);
            context.Request.Path = new PathString($"/Donation");
            TenantProvider tenantProvider = new TenantProvider(providers);

            InfrastructureDbContext infrastructureDbContext = this.fixture.ServiceProvider.GetRequiredService<InfrastructureDbContext>();

            DoarTenantMiddleware doarTenantMiddleware = new DoarTenantMiddleware(new RequestDelegate(context => { return Task.CompletedTask; }));
            await doarTenantMiddleware.Invoke(
                context,
                tenantProvider,
                fixture.ServiceProvider.GetRequiredService<IInfrastructureUnitOfWork>(),
                new KeyVaultConfigurationManager(
                    this.fixture.ServiceProvider.GetRequiredService<InfrastructureDbContext>(),
                    this.fixture.ServiceProvider.GetRequiredService<IWebHostEnvironment>(),
                    this.fixture.ServiceProvider.GetRequiredService<TelemetryClient>()),
                this.fixture.ServiceCollection);
            Model.Tenant tenant = context.GetTenant();
            Assert.NotNull(tenant);
            Assert.Equal(baseDomain, tenant?.DomainIdentifier);
        }
    }
}
