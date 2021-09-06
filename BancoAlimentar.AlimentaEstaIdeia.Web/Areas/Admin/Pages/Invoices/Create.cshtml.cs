﻿// -----------------------------------------------------------------------
// <copyright file="Create.cshtml.cs" company="Federação Portuguesa dos Bancos Alimentares Contra a Fome">
// Copyright (c) Federação Portuguesa dos Bancos Alimentares Contra a Fome. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace BancoAlimentar.AlimentaEstaIdeia.Web.Areas.Admin.Pages.Invoices
{
    using System.Threading.Tasks;
    using BancoAlimentar.AlimentaEstaIdeia.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class CreateModel : PageModel
    {
        private readonly BancoAlimentar.AlimentaEstaIdeia.Model.ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateModel"/> class.
        /// </summary>
        /// <param name="context"></param>
        public CreateModel(BancoAlimentar.AlimentaEstaIdeia.Model.ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Invoice Invoice { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        /// <summary>
        ///
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Invoices.Add(Invoice);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
