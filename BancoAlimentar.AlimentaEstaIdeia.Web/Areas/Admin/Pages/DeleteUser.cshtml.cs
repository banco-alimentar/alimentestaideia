// -----------------------------------------------------------------------
// <copyright file="DeleteUser.cshtml.cs" company="Federa��o Portuguesa dos Bancos Alimentares Contra a Fome">
// Copyright (c) Federa��o Portuguesa dos Bancos Alimentares Contra a Fome. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace BancoAlimentar.AlimentaEstaIdeia.Web.Areas.Admin.Pages
{
    using BancoAlimentar.AlimentaEstaIdeia.Repository;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class DeleteUserModel : PageModel
    {
        private readonly IUnitOfWork context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUserModel"/> class.
        /// </summary>
        /// <param name="context"></param>
        public DeleteUserModel(IUnitOfWork context)
        {
            this.context = context;
        }

        public void OnGet()
        {
          // this.context.User.DeleteAllUsers();
        }
    }
}
