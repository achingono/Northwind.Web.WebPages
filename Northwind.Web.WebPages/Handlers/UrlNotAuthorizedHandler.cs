using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace Northwind.Web.WebPages.Handlers
{
    class UrlNotAuthorizedHandler: StatusCodeHandler
    {
        #region Constructor
        public UrlNotAuthorizedHandler()
            : base(HttpStatusCode.Unauthorized) { }
        #endregion
    }
}