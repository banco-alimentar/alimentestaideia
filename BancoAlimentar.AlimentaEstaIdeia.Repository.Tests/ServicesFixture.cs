﻿// -----------------------------------------------------------------------
// <copyright file="ServicesFixture.cs" company="Federação Portuguesa dos Bancos Alimentares Contra a Fome">
// Copyright (c) Federação Portuguesa dos Bancos Alimentares Contra a Fome. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace BancoAlimentar.AlimentaEstaIdeia.Repository.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Azure.Extensions.AspNetCore.Configuration.Secrets;
    using Azure.Identity;
    using Azure.Security.KeyVault.Secrets;
    using BancoAlimentar.AlimentaEstaIdeia.Model;
    using BancoAlimentar.AlimentaEstaIdeia.Model.Identity;
    using BancoAlimentar.AlimentaEstaIdeia.Model.Initializer;
    using BancoAlimentar.AlimentaEstaIdeia.Web.Services;
    using Microsoft.ApplicationInsights;
    using Microsoft.ApplicationInsights.Extensibility;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// This class defines shared services class fixture for unit tests.
    /// </summary>
    public class ServicesFixture
    {
        private readonly ServiceCollection serviceCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesFixture"/> class.
        /// </summary>
        public ServicesFixture()
        {
            var jsongConfig = new ConfigurationBuilder()
              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
              .AddJsonFile("appsettings.json").Build();

            // the type specified here is just so the secrets library can
            // find the UserSecretId we added in the csproj file
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<ServicesFixture>(optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();

            this.serviceCollection = new ServiceCollection();

            this.serviceCollection.AddScoped<DonationRepository>();
            this.serviceCollection.AddMemoryCache();
            this.serviceCollection.AddScoped<ProductCatalogueRepository>();
            this.serviceCollection.AddScoped<FoodBankRepository>();
            this.serviceCollection.AddScoped<DonationItemRepository>();
            this.serviceCollection.AddScoped<InvoiceRepository>();
            this.serviceCollection.AddScoped<EasyPayBuilder>();
            this.serviceCollection.AddSingleton<IConfiguration>(this.Configuration);
            this.serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            this.serviceCollection.AddSingleton<IMemoryCache, MemoryCache>();
            this.serviceCollection.AddApplicationInsightsTelemetryWorkerService(this.Configuration["APPINSIGHTS_CONNECTIONSTRING"]);

            this.serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });
            this.serviceCollection.AddIdentityCore<WebUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
            })
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            this.serviceCollection.AddSingleton(new TelemetryClient(new TelemetryConfiguration(Guid.NewGuid().ToString())));

            this.ServiceProvider = this.serviceCollection.BuildServiceProvider();

            var context = this.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.EnsureCreated();
            this.UserManager = this.ServiceProvider.GetRequiredService<UserManager<WebUser>>();
            var roleManager = this.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            Task.Run(() => InitDatabase.Seed(context, this.UserManager, roleManager)).Wait();
            Task.Run(() => this.CreateTestDonation(context)).Wait();
        }

        /// <summary>
        /// Gets or sets the configuration system.
        /// </summary>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Gets the Service provider.
        /// </summary>
        public ServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// Gets the user manager.
        /// </summary>
        public UserManager<WebUser> UserManager { get; private set; }

        /// <summary>
        /// Gets the Donation id.
        /// </summary>
        public int DonationId { get; private set; } = 100;

        /// <summary>
        /// Gets the User id.
        /// </summary>
        public string UserId { get; private set; } = "d9b47304-18ab-4e72-ab7f-06c0663e4555";

        /// <summary>
        /// Gets the donation public id.
        /// </summary>
        public string PublicId { get; private set; } = "1c46a5b0-7a76-4b07-abe7-4bfcd252f420";

        /// <summary>
        /// Gets or sets the easypay transaction key.
        /// </summary>
        public string TransactionKey { get; set; } = "64b17f8d-f52b-4043-883c-e4479432ab3e";

        /// <summary>
        /// This method creates a test donation and its related dependencies which is being used in several tests.
        /// </summary>
        /// <param name="context">Application Db context.</param>
        /// <returns>Returns async task.</returns>
        private async Task CreateTestDonation(ApplicationDbContext context)
        {
            var donationItemRepository = this.ServiceProvider.GetRequiredService<DonationItemRepository>();
            var item = await context.ProductCatalogues.FirstOrDefaultAsync();
            var foodBank = await context.FoodBanks.FirstOrDefaultAsync();
            var user = new WebUser
            {
                Id = this.UserId,
                Email = "test@test.com",
                FullName = "Test User",
            };

            var donation = new Donation()
            {
                Id = this.DonationId,
                PublicId = new Guid(this.PublicId),
                DonationDate = DateTime.UtcNow,
                DonationAmount = 2.5,
                FoodBank = foodBank,
                Referral = string.Empty,
                DonationItems = donationItemRepository.GetDonationItems($"{item.Id}:1"),
                WantsReceipt = true,
                User = user,
                PaymentStatus = PaymentStatus.Payed,
                Nif = "123456789",
                Payments = new List<PaymentItem>(),
            };

            var creditCardPayment = new CreditCardPayment
            {
                Created = DateTime.Now,
                TransactionKey = this.TransactionKey,
                Url = "https://cc.test.easypay.pt/",
                Status = "ok",
            };

            donation.Payments.Add(new PaymentItem() { Donation = donation, Payment = creditCardPayment });
            donation.ConfirmedPayment = creditCardPayment;

            await this.UserManager.CreateAsync(user);
            await context.Donations.AddAsync(donation);
            await context.SaveChangesAsync();
        }
    }
}
