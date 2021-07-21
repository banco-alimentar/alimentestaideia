// -----------------------------------------------------------------------
// <copyright file="Donation.cshtml.cs" company="Federa��o Portuguesa dos Bancos Alimentares Contra a Fome">
// Copyright (c) Federa��o Portuguesa dos Bancos Alimentares Contra a Fome. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace BancoAlimentar.AlimentaEstaIdeia.Web.Pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using BancoAlimentar.AlimentaEstaIdeia.Model;
    using BancoAlimentar.AlimentaEstaIdeia.Model.Identity;
    using BancoAlimentar.AlimentaEstaIdeia.Repository;
    using BancoAlimentar.AlimentaEstaIdeia.Repository.ViewModel;
    using BancoAlimentar.AlimentaEstaIdeia.Web.Extensions;
    using BancoAlimentar.AlimentaEstaIdeia.Web.Features;
    using BancoAlimentar.AlimentaEstaIdeia.Web.Model.Pages.Shared;
    using BancoAlimentar.AlimentaEstaIdeia.Web.Models;
    using BancoAlimentar.AlimentaEstaIdeia.Web.Telemetry;
    using BancoAlimentar.AlimentaEstaIdeia.Web.Validation;
    using Easypay.Rest.Client.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.Localization;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.Primitives;
    using Microsoft.FeatureManagement;

    public class DonationModel : PageModel
    {
        public const string DonationIdKey = "DonationIdKey";

        private readonly ILogger<IndexModel> logger;
        private readonly IUnitOfWork context;
        private readonly SignInManager<WebUser> signInManager;
        private readonly UserManager<WebUser> userManager;
        private readonly IFeatureManager featureManager;
        private readonly IStringLocalizer localizer;
        private bool isPostRequest;

        public DonationModel(
            ILogger<IndexModel> logger,
            IUnitOfWork context,
            SignInManager<WebUser> signInManager,
            UserManager<WebUser> userManager,
            IStringLocalizerFactory stringLocalizerFactory,
            IFeatureManager featureManager)
        {
            this.logger = logger;
            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.featureManager = featureManager;
            this.localizer = stringLocalizerFactory.Create("Pages.Donation", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NameRequired")]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NameStringLength")]
        [DisplayAttribute(Name = "Nome")]
        [BindProperty]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "AddressRequired")]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "AddressStringLength")]
        [DisplayAttribute(Name = "Morada")]
        [BindProperty]
        public string Address { get; set; }

        [StringLength(256, ErrorMessage = "O tamanho m�ximo para a localidade � {0} caracteres.")]
        [DisplayAttribute(Name = "Localidade")]
        [BindProperty]
        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "CountryRequired")]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "CountryStringLength")]
        [DisplayAttribute(Name = "Pa�s")]
        [BindProperty]
        public string Country { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NifRequired")]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NifStringLength")]
        [RegularExpression("^[0-9 ]*$", ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NifInvalid")]
        [Nif(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NifInvalid")]
        [DisplayAttribute(Name = "NIF")]
        [BindProperty]
        public string Nif { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "EmailRequired")]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "EmailStringLength")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "EmailInvalid")]
        [DisplayAttribute(Name = "Email")]
        [BindProperty]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "PostalCodeRequired")]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "PostalCodeStringLength")]
        [DisplayAttribute(Name = "C. Postal")]
        [BindProperty]
        public string PostalCode { get; set; }

        [DisplayAttribute(Name = "Foto")]
        [BindProperty]
        public IFormFile Picture { get; set; }

        public bool Private { get; set; }

        [DisplayAttribute(Name = "Escolha o Banco Alimentar para o qual quer doar")]
        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "FoodBankIdRequired")]
        [BindProperty]
        public int FoodBankId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "AmountInvalid")]
        [MinimumValue(0.5, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "MinAmount")]
        [DisplayAttribute(Name = "Valor a doar")]
        [BindProperty]
        public double Amount { get; set; }

        [BindProperty]
        public string DonatedItems { get; set; }

        [BindProperty]
        public string Hidden { get; set; }

        [BindProperty]
        public bool WantsReceipt { get; set; }

        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NameStringLength")]
        [DisplayAttribute(Name = "Empresa")]
        [BindProperty]
        public string CompanyName { get; set; }

        [MustBeChecked(ErrorMessage = "Deve aceitar a Pol�tica de Privacidade.")]
        [BindProperty]
        public bool AcceptsTerms { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if the user want a subscription for the current donation.
        /// </summary>
        [BindProperty]
        public bool IsSubscriptionEnabled { get; set; }

        public bool IsCompany { get; set; }

        public bool IsPrivate { get; set; }

        public List<TotalDonationsResult> TotalDonations { get; set; }

        public IReadOnlyList<ProductCatalogue> ProductCatalogue { get; set; }

        [BindProperty]
        public List<SelectListItem> FoodBankList { get; set; }

        public LoginSharedModel LoginSharedModel { get; set; }

        public WebUser CurrentUser { get; set; }

        [BindProperty]
        public Donation CurrentDonationFlow { get; set; }

        /// <summary>
        /// Gets or sets a value indicating what is the selected subscription frequency.
        /// </summary>
        [BindProperty]
        public string SubscriptionFrequencySelected { get; set; }

        /// <summary>
        /// Gets or sets a value indicating what is the subscription frecuency.
        /// </summary>
        [BindProperty]
        public List<SelectListItem> SubscriptionFrequency { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            bool isMaintenanceEanbled = await featureManager.IsEnabledAsync(nameof(MaintenanceFlags.EnableMaintenance));
            if (isMaintenanceEanbled)
            {
                return RedirectToPage("/Maintenance");
            }
            else
            {
                await Load();
                return Page();
            }
        }

        public void LoadDonationFromFlow()
        {
            string donationPublicId = this.HttpContext.Session.GetString(DonationFlowTelemetryInitializer.DonationSessionKey);
            if (Guid.TryParse(donationPublicId, out Guid donationId))
            {
                int id = this.context.Donation.GetDonationIdFromPublicId(donationId);
                if (id > 0)
                {
                    CurrentDonationFlow = this.context.Donation.GetFullDonationById(id);
                    if (CurrentDonationFlow != null)
                    {
                        if (!isPostRequest)
                        {
                            LoadUserInformation(CurrentDonationFlow.User);
                            LoadUserAddressInformation(CurrentDonationFlow.User.Address);

                            this.WantsReceipt = CurrentDonationFlow.WantsReceipt ?? false;
                        }
                    }
                }
                else
                {
                    CurrentDonationFlow = null;
                }
            }
            else
            {
                CurrentDonationFlow = null;
            }
        }

        private void LoadUserInformation(WebUser user)
        {
            if (user != null)
            {
                this.Name = user.FullName;
                this.Nif = user.Nif;
                this.Email = user.Email;
                this.CompanyName = user.CompanyName;
            }
        }

        private void LoadUserAddressInformation(DonorAddress address)
        {
            if (address != null)
            {
                this.Address = address.Address1;
                this.City = address.City;
                this.PostalCode = address.PostalCode;
                this.Country = address.Country;
            }
        }

        public async Task<ActionResult> OnPost()
        {
            isPostRequest = true;
            await Load();

            Guid donationId = Guid.NewGuid();
            if (this.HttpContext.Items.ContainsKey(DonationFlowTelemetryInitializer.DonationSessionKey))
            {
                donationId = (Guid)this.HttpContext.Items[DonationFlowTelemetryInitializer.DonationSessionKey];
            }
            else
            {
                this.HttpContext.Items.Add(DonationFlowTelemetryInitializer.DonationSessionKey, donationId);
            }

            this.HttpContext.Session.SetString(DonationFlowTelemetryInitializer.DonationSessionKey, donationId.ToString());

            bool isManualUser = false;

            CurrentUser = await userManager.GetUserAsync(new ClaimsPrincipal(User.Identity));
            if (CurrentUser == null)
            {
                DonorAddress address = null;
                if (WantsReceipt)
                {
                    address = new DonorAddress()
                    {
                        Address1 = Address,
                        City = City,
                        PostalCode = PostalCode,
                        Country = Country,
                    };
                }

                CurrentUser = this.context.User.FindOrCreateWebUser(
                    Email,
                    CompanyName,
                    Nif,
                    Name,
                    address);

                if (CurrentUser != null)
                {
                    isManualUser = true;
                }
            }
            else
            {
                this.ModelState.Remove("Name");
                this.ModelState.Remove("Nif");
                this.ModelState.Remove("Country");
                this.ModelState.Remove("Email");
                this.ModelState.Remove("Address");
                this.ModelState.Remove("PostalCode");
                if (CurrentUser.EmailConfirmed)
                {
                    WantsReceipt = true;
                }
            }

            if (ModelState.IsValid)
            {
                SetCurrentUser();
                var donationItems = this.context.DonationItem.GetDonationItems(DonatedItems);
                double amount = 0d;
                foreach (var item in donationItems)
                {
                    amount += item.Quantity * item.Price;
                }

                Donation donation = null;
                (var referral_code, var referral) = GetReferral();
                if (CurrentDonationFlow == null)
                {
                    donation = new Donation()
                    {
                        PublicId = donationId,
                        DonationDate = DateTime.UtcNow,
                        DonationAmount = amount,
                        FoodBank = this.context.FoodBank.GetById(FoodBankId),
                        Referral = referral_code,
                        ReferralEntity = referral,
                        DonationItems = this.context.DonationItem.GetDonationItems(DonatedItems),
                        WantsReceipt = WantsReceipt,
                        User = CurrentUser,
                        PaymentStatus = PaymentStatus.WaitingPayment,
                        Nif = isManualUser ? Nif : null,
                    };

                    this.context.Donation.Add(donation);
                }
                else
                {
                    donation = CurrentDonationFlow;
                    if (donation.DonationItems != null)
                    {
                        this.context.DonationItem.RemoveRange(donation.DonationItems);
                        donation.DonationItems.Clear();
                    }

                    donation.DonationDate = DateTime.UtcNow;
                    donation.DonationAmount = amount;
                    donation.FoodBank = this.context.FoodBank.GetById(FoodBankId);
                    donation.Referral = referral_code;
                    donation.ReferralEntity = referral;
                    donation.DonationItems = this.context.DonationItem.GetDonationItems(DonatedItems);
                    donation.WantsReceipt = WantsReceipt;
                    donation.User = CurrentUser;
                    donation.PaymentStatus = PaymentStatus.WaitingPayment;
                }

                this.context.Complete();

                TempData["Donation"] = donation.Id;
                HttpContext.Session.SetInt32(DonationIdKey, donation.Id);

                if (IsSubscriptionEnabled)
                {
                    TempData["SubscriptionFrequencySelected"] = SubscriptionFrequencySelected;
                    return this.RedirectToPage("/SubscriptionPayment");
                }
                else
                {
                    return this.RedirectToPage("/Payment");
                }
            }
            else
            {
                if (isManualUser)
                {
                    CurrentUser = null;
                }

                CurrentDonationFlow = new Donation();
                CurrentDonationFlow.FoodBank = this.context.FoodBank.GetById(FoodBankId);
                CurrentDonationFlow.DonationItems = this.context.DonationItem.GetDonationItemsForModelException(DonatedItems);

                return Page();
            }
        }

        private void SetCurrentUser()
        {
            if (CurrentUser != null)
            {
                if (this.HttpContext.Items.ContainsKey(UserAuthenticationTelemetryInitializer.CurrentUserKey))
                {
                    this.HttpContext.Items[UserAuthenticationTelemetryInitializer.CurrentUserKey] = CurrentUser;
                }
                else
                {
                    this.HttpContext.Items.Add(UserAuthenticationTelemetryInitializer.CurrentUserKey, CurrentUser);
                }
            }
        }

        private (string, Referral) GetReferral()
        {
            StringValues queryValue;
            string result = null;
            if (this.Request.Query.TryGetValue("Referral", out queryValue))
            {
                result = queryValue.ToString();
            }
            else
            {
                if (this.Request.Cookies.TryGetValue("Referral", out result))
                {
                }
            }

            Referral referral = null;

            if (!string.IsNullOrWhiteSpace(result))
            {
                referral = this.context.ReferralRepository.GetActiveCampaignsByCode(result);
            }

            return (result, referral);
        }

        private async Task Load()
        {
            Claim id = User.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUser = this.context.User.FindUserById(id?.Value);
            SetCurrentUser();
            LoadDonationFromFlow();
            LoadUserInformation(CurrentUser);
            LoadUserAddressInformation(CurrentUser?.Address);
            if (CurrentUser != null)
            {
                WantsReceipt = true;
            }

            ProductCatalogue = this.context.ProductCatalogue.GetCurrentProductCatalogue();
            TotalDonations = this.context.Donation.GetTotalDonations(ProductCatalogue);
            var foodBanks = this.context.FoodBank.GetAll().OrderBy(x => x.Name).ToList();
            FoodBankList = new List<SelectListItem>();
            int count = 0;
            int index = -1;
            foreach (var item in foodBanks)
            {
                bool selected = false;
                if (this.CurrentDonationFlow != null &&
                    this.CurrentDonationFlow.FoodBank != null &&
                    this.CurrentDonationFlow.FoodBank.Id == item.Id)
                {
                    selected = true;
                    index = count;
                }

                FoodBankList.Add(new SelectListItem(item.Name, item.Id.ToString(), selected));
                count++;
            }

            if (index != -1)
            {
                var targetFoodBank = FoodBankList.ElementAt(index);
                FoodBankList.RemoveAt(index);
                FoodBankList.Insert(0, targetFoodBank);
            }
            else
            {
                FoodBankList.Insert(0, new SelectListItem(string.Empty, string.Empty));
            }

            LoginSharedModel = new LoginSharedModel()
            {
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
                ReturnUrl = string.IsNullOrEmpty(this.Request.Path) ? "~/" : $"~{this.Request.Path.Value + this.Request.QueryString}",
                IsUserLogged = User.Identity.IsAuthenticated,
            };

            SubscriptionFrequency = new List<SelectListItem>();
            foreach (var item in Enum.GetNames(typeof(PaymentSubscription.FrequencyEnum)))
            {
                string value = item.TrimStart('_');
                SubscriptionFrequency.Add(new SelectListItem(value, value));
            }
        }
    }
}
