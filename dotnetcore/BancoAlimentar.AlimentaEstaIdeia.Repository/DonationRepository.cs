﻿namespace BancoAlimentar.AlimentaEstaIdeia.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BancoAlimentar.AlimentaEstaIdeia.Model;
    using BancoAlimentar.AlimentaEstaIdeia.Repository.ViewModel;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Default implementation for the <see cref="Donation"/> repository pattern.
    /// </summary>
    public class DonationRepository : GenericRepository<Donation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DonationRepository"/> class.
        /// </summary>
        /// <param name="context"><see cref="ApplicationDbContext"/> instance.</param>
        public DonationRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Gets total donations sum for all the elements in the product catalogues.
        /// </summary>
        /// <param name="items">The list of <see cref="ProductCatalogue"/> that belong to the current campaign.</param>
        /// <returns>Return a <see cref="TotalDonationsResult"/> list.</returns>
        public List<TotalDonationsResult> GetTotalDonations(IReadOnlyCollection<ProductCatalogue> items)
        {
            List<TotalDonationsResult> result = new List<TotalDonationsResult>();

            foreach (var product in items)
            {
                int sum = this.DbContext.DonationItems.Where(p => p.ProductCatalogue == product).Sum(p => p.Quantity);
                double total = product.Quantity.Value * sum;
                result.Add(new TotalDonationsResult()
                {
                    Cost = product.Cost,
                    Description = product.Description,
                    IconUrl = product.IconUrl,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Total = sum,
                    TotalCost = total,
                    UnitOfMeasure = product.UnitOfMeasure,
                });
            }

            return result;
        }

        public void UpdateDonationPaymentId(Donation donation, string paymentId, string token = null, string payerId = null)
        {
            if (donation != null && !string.IsNullOrEmpty(paymentId))
            {
                PayPalPayment paypalPayment = this.DbContext.PayPalPayments
                    .Where(p => p.PayPalPaymentId == paymentId)
                    .FirstOrDefault();

                if (paypalPayment == null)
                {
                    paypalPayment = new PayPalPayment();
                    paypalPayment.Donation = donation;
                    paypalPayment.Created = DateTime.UtcNow;

                    this.DbContext.PayPalPayments.Add(paypalPayment);
                }

                paypalPayment.PayPalPaymentId = paymentId;
                paypalPayment.Token = token;
                paypalPayment.PayerId = payerId;

                this.DbContext.SaveChanges();
            }
        }

        public void UpdateMultiBankPayment(Donation donation, string transactionKey, string entity, string reference)
        {
            if (donation != null && !string.IsNullOrEmpty(transactionKey))
            {
                donation.ServiceEntity = entity;
                donation.ServiceReference = reference;
                MultiBankPayment multiBankPayment = this.DbContext.MultiBankPayments
                    .Where(p => p.TransactionKey == transactionKey)
                    .FirstOrDefault();

                if (multiBankPayment == null)
                {
                    multiBankPayment = new MultiBankPayment();
                    multiBankPayment.Donation = donation;
                    multiBankPayment.Created = DateTime.UtcNow;

                    this.DbContext.MultiBankPayments.Add(multiBankPayment);
                }

                multiBankPayment.TransactionKey = transactionKey;

                this.DbContext.SaveChanges();
            }
        }

        public void CompleteMultiBankPayment(string id, string transactionkey, string type, string status, string message)
        {
            MultiBankPayment payment = this.DbContext.MultiBankPayments
                .Include(p => p.Donation)
                .Where(p => p.TransactionKey == transactionkey)
                .FirstOrDefault();

            if (payment != null)
            {
                payment.EasyPayPaymentId = id;
                payment.Donation.PaymentStatus = PaymentStatus.Payed;
                payment.Type = type;
                payment.Status = status;
                payment.Message = message;

                this.DbContext.SaveChanges();
            }
        }

        public void CreateCreditCardPaymnet(Donation donation, string transactionKey, string url)
        {
            if (donation != null && !string.IsNullOrEmpty(transactionKey))
            {
                CreditCardPayment creditCardPayment = this.DbContext.CreditCardPayments
                    .Where(p => p.TransactionKey == transactionKey)
                    .FirstOrDefault();

                if (creditCardPayment == null)
                {
                    creditCardPayment = new CreditCardPayment();
                    creditCardPayment.Donation = donation;
                    creditCardPayment.Created = DateTime.UtcNow;

                    this.DbContext.CreditCardPayments.Add(creditCardPayment);
                }

                creditCardPayment.TransactionKey = transactionKey;
                creditCardPayment.Url = url;

                this.DbContext.SaveChanges();
            }
        }

        public void CompleteCreditCardPayment(
            string id,
            string transactionkey,
            float requested,
            float paid,
            float fixedFee,
            float variableFee,
            float tax,
            float transfer)
        {
            CreditCardPayment payment = this.DbContext.CreditCardPayments
                .Include(p => p.Donation)
                .Where(p => p.TransactionKey == transactionkey)
                .FirstOrDefault();

            if (payment != null)
            {
                payment.EasyPayPaymentId = id;
                payment.Donation.PaymentStatus = PaymentStatus.Payed;
                payment.Requested = requested;
                payment.Paid = paid;
                payment.FixedFee = fixedFee;
                payment.VariableFee = variableFee;
                payment.Tax = tax;
                payment.Transfer = transfer;
                this.DbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the full <see cref="Donation"/> object that contains the user and the donation users.
        /// </summary>
        /// <param name="donationId">Donation id.</param>
        /// <returns>A reference to the <see cref="Donation"/>.</returns>
        public Donation GetFullDonationById(int donationId)
        {
            return this.DbContext.Donations
                .Where(p => p.Id == donationId)
                .Include(p => p.User)
                .Include(p => p.DonationItems)
                .FirstOrDefault();
        }

        /// <summary>
        /// Get all the user donations in time.
        /// </summary>
        /// <param name="userId">A reference to the user id.</param>
        /// <returns>A <see cref="List<Donation>"/> of donations.</returns>
        public List<Donation> GetUserDonation(string userId)
        {
            return this.DbContext.Donations
                .Include(p => p.DonationItems)
                .Include(p => p.FoodBank)
                .Where(p => p.User.Id == userId)
                .ToList();
        }
    }
}
