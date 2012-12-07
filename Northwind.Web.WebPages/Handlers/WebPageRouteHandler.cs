using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.IO;

namespace Northwind.Web.WebPages.Handlers
{
    public class WebPageRouteHandler : IRouteHandler
    {
        #region Properties
        public string VirtualPath { get; private set; }
        public bool CheckAccess { get; private set; }
        #endregion

        #region Constructor
        public WebPageRouteHandler(string virtualPath, bool checkAccess)
        {
            this.VirtualPath = virtualPath;
            this.CheckAccess = checkAccess;
        }
        #endregion

        #region IRouteHandler Members
        /// <summary>
        /// Provides the object that processes the request.
        /// </summary>
        /// <param name="requestContext">An object that encapsulates information about the request.</param>
        /// <returns>An <see cref="System.Web.IHttpHandler"/> object that processes the request.</returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            if (requestContext == null)
                throw new ArgumentNullException("requestContext");

            // get the current user
            var user = requestContext.HttpContext.User;

            // get the path of the requested url
            var virtualPath = requestContext.HttpContext.Request.Path;
            var physicalPath = requestContext.HttpContext.Request.PhysicalPath;

            // verify user's permissions 
            //if (this.CheckAccess
            //&& !this.CheckUrlAccess(VirtualPathUtility.ToAppRelative(virtualPath), requestContext))
            //    return new UrlNotAuthorizedHandler();

            // Use the file if it exists, otherwise use the routed file
            if (!File.Exists(physicalPath))
            {
                var routeValues = requestContext.RouteData.Values;
                virtualPath = this.VirtualPath;
                foreach (var key in routeValues.Keys)
                {
                    virtualPath = virtualPath.Replace("{" + key + "}", routeValues[key].ToString());
                }
            }

            if (!File.Exists(requestContext.HttpContext.Server.MapPath(virtualPath)))
            {
                return new UrlNotFoundHandler();
            }

            return new WebPageHttpHandler(virtualPath); ;
        }

        /// <summary>
        /// Check if current user has access to the virtual path
        /// </summary>
        /// <param name="virtualPath">The virtual path to check</param>
        /// <param name="requestContext">An object that encapsulates information about the request.</param>
        /// <returns>true if user has access</returns>
        //private bool CheckUrlAccess(string virtualPath, RequestContext requestContext)
        //{
        //    IPrincipal user = requestContext.HttpContext.User;
        //    if (user == null)
        //        user = new GenericPrincipal(new GenericIdentity(string.Empty, string.Empty), new string[0]);

        //    return this.CheckUrlAccessWithAssert(virtualPath, requestContext, user);
        //}

        /// <summary>
        /// Check if the specified use has access to the virtual path
        /// </summary>
        /// <param name="virtualPath">The virtual path to check</param>
        /// <param name="requestContext">An object that encapsulates information about the request.</param>
        /// <param name="user">The <see cref="System.Security.Principal.IPrincipal"/> object that encapsulates information about the user</param>
        /// <returns>true if user has access</returns>
        //[SecurityPermission(SecurityAction.Assert, Unrestricted = true)]
        //private bool CheckUrlAccessWithAssert(string virtualPath, RequestContext requestContext, IPrincipal user)
        //{
        //    return UrlAuthorizationModule.CheckUrlAccessForPrincipal(virtualPath, user, requestContext.HttpContext.Request.HttpMethod);
        //}
        #endregion
    }
}