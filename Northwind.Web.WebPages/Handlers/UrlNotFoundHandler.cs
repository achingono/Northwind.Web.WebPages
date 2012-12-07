using System.Net;

namespace Northwind.Web.WebPages.Handlers
{
    class UrlNotFoundHandler : StatusCodeHandler
    {
        #region Constructor
        public UrlNotFoundHandler()
            : base(HttpStatusCode.NotFound) { }
        #endregion
    }
}