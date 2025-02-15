﻿// <copyright file="BasePayment.cs" company="Federação Portuguesa dos Bancos Alimentares Contra a Fome">
// Copyright (c) Federação Portuguesa dos Bancos Alimentares Contra a Fome. All rights reserved.
// </copyright>

namespace BancoAlimentar.AlimentaEstaIdeia.Model
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Base class for the payment process.
    /// </summary>
    public class BasePayment
    {
        /// <summary>
        /// Gets or sets the easypay transaction key.
        /// </summary>
        public string TransactionKey { get; set; }

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets when the payment was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets when the payment was completed.
        /// </summary>
        public DateTime? Completed { get; set; }

        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the Donation this payment belongs to.
        /// </summary>
        public Donation Donation { get; set; }
    }
}
