// -----------------------------------------------------------------------
// <copyright file="DonationHistory.cshtml.cs" company="Federa��o Portuguesa dos Bancos Alimentares Contra a Fome">
// Copyright (c) Federa��o Portuguesa dos Bancos Alimentares Contra a Fome. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace BancoAlimentar.AlimentaEstaIdeia.Web.Areas.Identity.Pages.Account.Manage
{
    using System.Threading.Tasks;
    using BancoAlimentar.AlimentaEstaIdeia.Model;
    using BancoAlimentar.AlimentaEstaIdeia.Model.Identity;
    using BancoAlimentar.AlimentaEstaIdeia.Repository;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class DonationHistoryModel : PageModel
    {
        private readonly UserManager<WebUser> userManager;
        private readonly IUnitOfWork context;

        public DonationHistoryModel(
            UserManager<WebUser> userManager,
            IUnitOfWork context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetDataTableData()
        {
            var user = await userManager.GetUserAsync(User);
            var donations = this.context.Donation.GetUserDonation(user.Id);
            JArray list = new JArray();
            int count = 1;
            foreach (var item in donations)
            {
                JObject obj = new JObject();
                obj.Add("Id", count);
                obj.Add("DonationDate", item.DonationDate.ToString());
                obj.Add("FoodBank", item.FoodBank != null ? item.FoodBank.Name : string.Empty);
                obj.Add("DonationAmount", item.DonationAmount);
                obj.Add("PublicId", item.PublicId.ToString());
                JArray paymentArray = new JArray();
                foreach (var payment in item.Payments)
                {
                    JObject paymentItem = new JObject();
                    paymentItem.Add("PaymentType", this.context.Donation.GetPaymentType(payment.Payment).ToString());
                    if (payment.Payment is CreditCardPayment)
                    {
                        CreditCardPayment creditCardPayment = (CreditCardPayment)payment.Payment;
                        if (creditCardPayment.Status != Constants.CreditCardSucceed)
                        {
                            paymentItem.Add("PaymentUrl", creditCardPayment.Url);
                        }

                        paymentItem.Add("PaymentStatus", creditCardPayment.Status);
                    }
                    else if (payment.Payment is PayPalPayment)
                    {
                        PayPalPayment payPalPayment = (PayPalPayment)payment.Payment;
                    }

                    paymentItem.Add("PaymentItemId", payment.Payment.Id);
                    paymentArray.Add(paymentItem);
                }

                obj.Add("Payments", paymentArray);
                obj.Add("PaymentStatus", item.PaymentStatus.ToString());
                list.Add(obj);
                count++;
            }

            return new ContentResult()
            {
                Content = JsonConvert.SerializeObject(list),
                ContentType = "application/json",
                StatusCode = 200,
            };
        }
    }
}
