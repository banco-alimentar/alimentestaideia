﻿// <copyright file="EasyPayBaseClass.cs" company="Federação Portuguesa dos Bancos Alimentares Contra a Fome">
// Copyright (c) Federação Portuguesa dos Bancos Alimentares Contra a Fome. All rights reserved.
// </copyright>

namespace BancoAlimentar.AlimentaEstaIdeia.Model
{
    /// <summary>
    /// Base class for all easypay payments.
    /// </summary>
    public abstract class EasyPayBaseClass : BasePayment
    {
        /// <summary>
        /// Gets or sets the easypay transaction key.
        /// </summary>
        public string TransactionKey { get; set; }

        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the easypay notification id.
        /// </summary>
        public string EasyPayPaymentId { get; set; }
    }
}
