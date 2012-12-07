using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Northwind.Web.WebPages.Handlers
{
    public class WebPageHttpHandler : IHttpHandler
    {
        #region Fields
        private readonly Lazy<WebPageRenderingBase> _startPage;
        #endregion

        #region Properties
        internal WebPage Page { get; private set; }
        #endregion

        #region Constructor
        public WebPageHttpHandler(string virtualPath)
        {
            // create a new WebPage instance for use when processing the request
            this.Page = (WebPage)WebPageBase.CreateInstanceFromVirtualPath(virtualPath);

            Func<WebPageRenderingBase> func = null;
            if (func == null)
            {
                func = delegate
                {
                    return StartPage.GetStartPage(this.Page, "_PageStart", System.Web.WebPages.WebPageHttpHandler.GetRegisteredExtensions());
                };
            }
            this._startPage = new Lazy<WebPageRenderingBase>(func);
        }
        #endregion

        #region IHttpHandler Members

        /// <summary>
        ///     Gets a value indicating whether another request can use the <see cref="System.Web.IHttpHandler"/>
        ///     instance.        
        /// </summary>
        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        /// Process the specified HTTP Web request
        /// </summary>
        /// <param name="context">A <see cref="System.Web.HttpContext"/> object to service the HTTP request.</param>
        public void ProcessRequest(HttpContext context)
        {
            var contextWrapper = new HttpContextWrapper(context);
            var pageContext = new WebPageContext(contextWrapper, this.Page, null);

            this.Page.ExecutePageHierarchy(pageContext, contextWrapper.Response.Output, this._startPage.Value);
        }

        #endregion
    }
}