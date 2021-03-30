﻿namespace BancoAlimentar.AlimentaEstaIdeia.Web.Pages.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BancoAlimentar.AlimentaEstaIdeia.Web.Pages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using BancoAlimentar.AlimentaEstaIdeia.Repository;
    using BancoAlimentar.AlimentaEstaIdeia.Model;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using Easypay.Rest.Client.Client;
    using Easypay.Rest.Client.Api;
    using Easypay.Rest.Client.Model;
    using System.IO;
    using System.Net.Http;

    [TestClass()]
    public class PaymentModelTests
    {
        IConfiguration Configuration { get; set; }
        ServiceCollection ServiceCollection { get; set; }

        ServiceProvider ServiceProvider { get; set; }

        public PaymentModelTests()
        {
            ServiceCollection = new ServiceCollection();

            // the type specified here is just so the secrets library can 
            // find the UserSecretId we added in the csproj file
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<PaymentModelTests>();

            Configuration = builder.Build();

            ServiceCollection.AddScoped<DonationRepository>();
            ServiceCollection.AddScoped<ProductCatalogueRepository>();
            ServiceCollection.AddScoped<FoodBankRepository>();
            ServiceCollection.AddScoped<DonationItemRepository>();
            ServiceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            ServiceCollection.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("BancoAlimentar.AlimentaEstaIdeia.Web")));

            ServiceProvider = ServiceCollection.BuildServiceProvider();
        }

        [TestMethod()]
        public async Task EasyPayTest()
        {
            IUnitOfWork context = this.ServiceProvider.GetRequiredService<IUnitOfWork>();
            Donation temporalDonation = CreateTemporalDonation(context);
            PaymentModel paymentModel = new PaymentModel(
                this.Configuration,
                this.ServiceProvider.GetRequiredService<IUnitOfWork>())
            {
                DonationId = temporalDonation.Id,
                Donation = temporalDonation,
            };

            SinglePaymentResponse targetPayment = null;
            
            try
            {
                SinglePaymentRequest paymentRequest = new SinglePaymentRequest()
                {
                    Key = temporalDonation.Id.ToString(),
                    Type = SinglePaymentRequest.TypeEnum.Sale,
                    Currency = SinglePaymentRequest.CurrencyEnum.EUR,
                    Customer = new SinglePaymentUpdateRequestCustomer()
                    {
                        Name = temporalDonation.User.UserName,
                        Email = temporalDonation.User.Email,
                        Phone = temporalDonation.User.PhoneNumber,
                        FiscalNumber = temporalDonation.User.Nif,
                        Language = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName,
                        Key = temporalDonation.User.Id,
                    },
                    Value = (float)temporalDonation.ServiceAmount,
                    Method = SinglePaymentRequest.MethodEnum.Mb,
                    Capture = new SinglePaymentRequestCapture(
                        transactionKey: Guid.NewGuid().ToString(), 
                        descriptive: "AlimentaEstaideapayment"),
                };

                Configuration easypayConfig = new Configuration();
                easypayConfig.BasePath = Configuration["Easypay:BaseUrl"] + "/2.0";
                easypayConfig.ApiKey.Add("AccountId", Configuration["Easypay:AccountId"]);
                easypayConfig.ApiKey.Add("ApiKey", Configuration["Easypay:ApiKey"]);
                easypayConfig.DefaultHeaders.Add("Content-Type", "application/json");
                easypayConfig.UserAgent = $" {GetType().Assembly.GetName().Name}/{GetType().Assembly.GetName().Version.ToString()}(Easypay.Rest.Client/{Easypay.Rest.Client.Client.Configuration.Version})";
                SinglePaymentApi easyPayApiClient = new SinglePaymentApi(easypayConfig);
                targetPayment = await easyPayApiClient.CreateSinglePaymentAsync(paymentRequest, CancellationToken.None);

                temporalDonation.ServiceEntity = targetPayment.Method.Entity.ToString();
                temporalDonation.ServiceReference = targetPayment.Method.Reference;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
            finally
            {
                context.DonationItem.RemoveRange(temporalDonation.DonationItems);
                context.Donation.Remove(temporalDonation);
                int affectedRows = context.Complete();
                Assert.IsTrue(affectedRows > 0);
            }

            Assert.IsTrue(targetPayment.Status == "ok", "Payment was not successfull");
            Assert.IsTrue(targetPayment.Id == Guid.Empty, "No payment Id returned");
            Assert.IsTrue(targetPayment.Message.Count <= 0 , "No payment status message returned");
            Assert.IsTrue(targetPayment.Message[0] == "Your request was successfully created", $"Not success message: {targetPayment.Message[0]}");
            Assert.IsTrue(targetPayment.Method != null, "No return method for created single payment");
            Assert.IsTrue(targetPayment.Method.Status == PaymentSingleMethod.StatusEnum.Pending, "New single payment Method Status not pending");
            Assert.IsTrue(targetPayment.Method.Entity != 0, "New single payment Method (Mb) Entity not valid");
            Assert.IsTrue(targetPayment.Method.Reference != null, "New single payment Method (Mb) Reference not valid");
            Assert.IsTrue(targetPayment.Method.Url != null, "New single payment Method (Mb) Url is null");
        }

        private Donation CreateTemporalDonation(IUnitOfWork context)
        {
            Donation result = new Donation()
            {
                DonationDate = DateTime.UtcNow,
                DonationItems = new List<DonationItem>(),
                FoodBank = context.FoodBank.GetById(2),
                Referral = "Testing",
                ServiceAmount = 23,
                User = context.User.FindUserById("0b93837a-7de9-4cfa-95a8-e4dc45d06be5"),
                WantsReceipt = false,
                PaymentStatus = PaymentStatus.WaitingPayment,
            };

            int count = 0;
            foreach (var item in context.ProductCatalogue.GetAll().ToList())
            {
                result.DonationItems.Add(new DonationItem()
                {
                    Donation = result,
                    ProductCatalogue = item,
                    Price = item.Cost,
                    Quantity = ++count,
                });
            }

            context.Donation.Add(result);
            int affectedRows = context.Complete();
            Assert.IsTrue(affectedRows > 0);

            return result;
        }
    }
}