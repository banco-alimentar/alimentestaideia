﻿// -----------------------------------------------------------------------
// <copyright file="DonationTelemetryMiddleware.cs" company="Federação Portuguesa dos Bancos Alimentares Contra a Fome">
// Copyright (c) Federação Portuguesa dos Bancos Alimentares Contra a Fome. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace BancoAlimentar.AlimentaEstaIdeia.Web.Telemetry
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class DonationTelemetryMiddleware
    {
        public const string SessionIdKey = "SessionId";
        private readonly RequestDelegate next;

        public DonationTelemetryMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string donationId = httpContext.Session.GetString(DonationFlowTelemetryInitializer.DonationSessionKey);
            if (!string.IsNullOrEmpty(donationId))
            {
                httpContext.Items.Add(DonationFlowTelemetryInitializer.DonationSessionKey, new Guid(donationId));
            }

            if (httpContext.Session.IsAvailable)
            {
                httpContext.Items.Add(SessionIdKey, httpContext.Session.Id);
            }

            httpContext.Response.Headers.Add("Request-Id", Activity.Current.RootId);

            return next(httpContext);
        }
    }
}
