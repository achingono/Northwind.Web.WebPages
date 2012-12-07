using System;
using System.Net;
using System.Web;

namespace Northwind.Web.WebPages.Handlers
{
    abstract class StatusCodeHandler : IHttpHandler
    {
        #region Properties
        public bool IsReusable
        {
            get { return true; }
        }

        public HttpStatusCode StatusCode { get; set; }
        #endregion

        #region Constructor
        public StatusCodeHandler(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }
        #endregion

        #region Methods
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.Cache.SetNoStore();
            context.Response.Cache.SetExpires(DateTime.MinValue);
            context.Response.StatusCode = (int)this.StatusCode;
            context.Response.StatusDescription = this.StatusCode.ToString("F");
            context.Response.End();
        }
        #endregion
    }
}