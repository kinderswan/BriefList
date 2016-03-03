using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.BriefList.WebUI.HelperExtension
{
    public static class AntiForgeryExtension
    {
        public static string RequestVerificationToken(this HtmlHelper helper)
        {
            return $"ncg-request-verification-token={GetTokenHeaderValue()}";
        }

        private static string GetTokenHeaderValue()
        {
            string cookieToken, formToken;
            System.Web.Helpers.AntiForgery.GetTokens(null, out cookieToken, out formToken);
            return cookieToken + ":" + formToken;
        }
    }
}