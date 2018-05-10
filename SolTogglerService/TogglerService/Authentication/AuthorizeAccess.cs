using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using TogglerService.Controllers;
using TogglerService.DTO;

namespace TogglerService.Authentication
{

    public class AuthorizeAccess : AuthorizeFilter
    {



        public AuthorizeAccess(AuthorizationPolicy policy) : base(policy)
        {


        }

        private readonly TogglerContext _context;




        public override Task OnAuthorizationAsync(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext context)
        { 
            base.OnAuthorizationAsync(context);
            
            
            var togglerBlue = _context.Toggler.FirstOrDefault(m => m.NameButton == "isButtonBlue");

            if ((togglerBlue != null) && (!togglerBlue.IsOn))
            {
                if (context.HttpContext.Request.Headers["Empresa"] != "service ABC")
                    return Task.FromException(new Exception("Access Denied"));
            }

            var togglerGreen = _context.Toggler.FirstOrDefault(m => m.NameButton == "isButtonGreen");

            if ((togglerGreen != null) && (togglerGreen.IsOn))
            {
                if (context.HttpContext.Request.Headers["Empresa"] != "service ABC")
                    return Task.FromException(new Exception("Access Denied"));
            }
            else
                return Task.FromException(new Exception("Access Denied"));

            var togglerRed = _context.Toggler.FirstOrDefault(m => m.NameButton == "isButtonRed");

            if ((togglerRed != null) && (!togglerRed.IsOn))
            {
                if (context.HttpContext.Request.Headers["Empresa"] == "service ABC")
                    return Task.FromException(new Exception("Access Denied"));
            }

            return Task.CompletedTask;
        }








    }
}
