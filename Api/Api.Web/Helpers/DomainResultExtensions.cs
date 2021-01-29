﻿using Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Web.Helpers
{
    public static class DomainResultExtensions
    {
        public static ProblemDetails ToProblemDetails(this DomainResult domainResult)
        {
            if (domainResult.Successed)
            {
                throw new InvalidOperationException();
            }

            var details = new ProblemDetails
            {
                Title = "Domain error"
            };

            details.Extensions["errors"] = new
            {
                domain = domainResult.Errors
            };

            return details;
        }
    }
}
