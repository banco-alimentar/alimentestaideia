// -----------------------------------------------------------------------
// <copyright file="SeleniumTests.cshtml.cs" company="Federa��o Portuguesa dos Bancos Alimentares Contra a Fome">
// Copyright (c) Federa��o Portuguesa dos Bancos Alimentares Contra a Fome. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace BancoAlimentar.AlimentaEstaIdeia.Web.Pages
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    /// <summary>
    /// Disable AI on the selenium tests.
    /// </summary>
    public class SeleniumTestsModel : PageModel
    {
        /// <summary>
        /// Execute the get operation.
        /// </summary>
        public void OnGet()
        {
            HttpContext.Session.SetString("DisableAI", "true");
        }
    }
}
