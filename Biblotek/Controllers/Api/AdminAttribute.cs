using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Biblotek.Controllers.Api
{
    internal class AdminAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string username = context.HttpContext.Session.GetString("username");

            //context.HttpContext.Session.SetString("loggedIn", "true");

            if (string.IsNullOrWhiteSpace(username))
            {
                context.HttpContext.Response.Redirect("/Login");
            }
        }
    }
}

