using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Northwind.Web
{
    public class Url
    {
        public static string ApiUrl(string controller)
        {
            return RouteTable.Routes.GetVirtualPath(null, "Api", new RouteValueDictionary { { "httproute", "" }, { "controller", controller } }).VirtualPath;
        }
    }
}