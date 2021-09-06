﻿// -----------------------------------------------------------------------
// <copyright file="Create.cshtml.cs" company="Federação Portuguesa dos Bancos Alimentares Contra a Fome">
// Copyright (c) Federação Portuguesa dos Bancos Alimentares Contra a Fome. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace BancoAlimentar.AlimentaEstaIdeia.Web.Areas.Admin.Pages.Campaigns
{
    using System.Collections.Generic;
    using BancoAlimentar.AlimentaEstaIdeia.Model;
    using BancoAlimentar.AlimentaEstaIdeia.Repository;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateModel"/> class.
        /// </summary>
        /// <param name="context"></param>
        public CreateModel(IUnitOfWork context)
        {
            this.context = context;
        }

        [BindProperty]
        public Campaign Campaign { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this.Campaign.ProductCatalogues = new List<ProductCatalogue>();

            Campaign currentCampaign = context.CampaignRepository.GetCurrentCampaign();
            foreach (var item in currentCampaign.ProductCatalogues)
            {
                this.Campaign.ProductCatalogues.Add(new ProductCatalogue()
                {
                    Cost = item.Cost,
                    Description = item.Description,
                    IconUrl = item.IconUrl,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    UnitOfMeasure = item.UnitOfMeasure,
                    Campaign = this.Campaign,
                });
            }

            context.CampaignRepository.Add(Campaign);
            context.Complete();

            return RedirectToPage("./Index");
        }
    }
}
