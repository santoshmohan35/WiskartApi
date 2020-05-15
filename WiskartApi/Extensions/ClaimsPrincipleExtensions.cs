using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WiskartApi.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string RetreiveEmailFromPrinciple(this ClaimsPrincipal user)
        {
            return user.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
    }
}
