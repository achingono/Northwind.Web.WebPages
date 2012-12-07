using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Profile;
using System.Web.Security;
using System.Web.Routing;

namespace Northwind.Web
{
    public static class Extensions
    {
        #region IPrincipal Extensions
        public static bool IsAuthenticated(this IPrincipal user)
        {
            bool result = false;

            if (user != null
                && user.Identity != null
                && !string.IsNullOrEmpty(user.Identity.Name))
            {
                ProfileBase p = ProfileBase.Create(user.Identity.Name);
                result = (user.Identity.IsAuthenticated
                && !p.IsAnonymous);
            }
            return result;
        }

        public static string Name(this IPrincipal user)
        {
            string username = "";

            if (user.IsAuthenticated())
            {
                username = user.Identity.Name;
            }
            return username;
        }

        public static string Email(this IPrincipal user)
        {
            string email = string.Empty;
            var member = Membership.GetUser(user.Identity.Name);
            if (member != null)
                email = member.Email;
            return email;
        }

        public static string IP(this IPrincipal user)
        {
            string address = "127.0.0.1";
            var context = HttpContext.Current;
            if (context != null
                && context.Request != null)
            {
                try
                {
                    address = context.Request.UserHostAddress;
                }
                catch (NullReferenceException) { }
            }
            return address;
        }

        public static bool IsAdministrator(this IPrincipal user)
        {
            return (user.IsAuthenticated() && user.IsInRole("Administrators"));
        }
        #endregion
    }
}