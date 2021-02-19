namespace BancoAlimentar.AlimentaEstaIdeia.Web.Pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using BancoAlimentar.AlimentaEstaIdeia.Model;
    using BancoAlimentar.AlimentaEstaIdeia.Model.Identity;
    using BancoAlimentar.AlimentaEstaIdeia.Repository;
    using BancoAlimentar.AlimentaEstaIdeia.Repository.ViewModel;
    using BancoAlimentar.AlimentaEstaIdeia.Web.Model.Pages.Shared;
    using BancoAlimentar.AlimentaEstaIdeia.Web.Models;
    using BancoAlimentar.AlimentaEstaIdeia.Web.Validation;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    public class DonationModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly SignInManager<WebUser> signInManager;
        private DonationRepository donationRepository;
        private ProductCatalogueRepository productCatalogueRepository;
        private FoodBankRepository foodBankRepository;

        public DonationModel(
            ILogger<IndexModel> logger,
            DonationRepository donationRepository,
            ProductCatalogueRepository productCatalogueRepository,
            FoodBankRepository foodBankRepository,
            SignInManager<WebUser> signInManager)
        {
            this.logger = logger;
            this.donationRepository = donationRepository;
            this.productCatalogueRepository = productCatalogueRepository;
            this.foodBankRepository = foodBankRepository;
            this.signInManager = signInManager;
        }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NameRequired")]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NameStringLength")]
        [DisplayAttribute(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "AddressRequired")]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "AddressStringLength")]
        [DisplayAttribute(Name = "Morada")]
        public string Address { get; set; }

        [StringLength(256, ErrorMessage = "O tamanho m�ximo para a localidade � {0} caracteres.")]
        [DisplayAttribute(Name = "Localidade")]
        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "CountryRequired")]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "CountryStringLength")]
        [DisplayAttribute(Name = "Pa�s")]
        public string Country { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NifRequired")]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NifStringLength")]
        [RegularExpression("^[0-9 ]*$", ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NifInvalid")]
        [Nif(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NifInvalid")]
        [DisplayAttribute(Name = "NIF")]
        public string Nif { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "EmailRequired")]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "EmailStringLength")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "EmailInvalid")]
        [DisplayAttribute(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "PostalCodeRequired")]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "PostalCodeStringLength")]
        [DisplayAttribute(Name = "C. Postal")]
        public string PostalCode { get; set; }

        [DisplayAttribute(Name = "Foto")]
        public IFormFile Picture { get; set; }

        public bool Private { get; set; }

        [DisplayAttribute(Name = "Escolha o Banco Alimentar para o qual quer doar")]
        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "FoodBankIdRequired")]
        public int FoodBankId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "AmountInvalid")]
        [Range(0.01, 9999.99, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "AmountInvalid")]
        [DisplayAttribute(Name = "Valor a doar")]
        public double Amount { get; set; }

        public string DonatedItems { get; set; }

        public string Hidden { get; set; }

        public bool WantsReceipt { get; set; }

        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "NameStringLength")]
        [DisplayAttribute(Name = "Empresa")]
        public string CompanyName { get; set; }

        [MustBeChecked(ErrorMessage = "Deve aceitar a Pol�tica de Privacidade.")]
        public bool AcceptsTerms { get; set; }

        public List<TotalDonationsResult> TotalDonations { get; set; }

        public List<ProductCatalogue> ProductCatalogue { get; set; }

        public List<FoodBank> FoodBanks { get; set; }

        public LoginSharedModel LoginSharedModel { get; set; }

        public async Task OnGetAsync()
        {
            TotalDonations = this.donationRepository.GetTotalDonations();
            ProductCatalogue = this.productCatalogueRepository.GetAll().ToList();
            FoodBanks = this.foodBankRepository.GetAll().ToList();

            LoginSharedModel = new LoginSharedModel()
            {
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
                ReturnUrl = Url.Content("~/"),
                IsUserLogged = User.Identity.IsAuthenticated,
            };
        }
    }
}
