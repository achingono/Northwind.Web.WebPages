using System.Web.Http;
using Northwind.Data;

namespace Northwind.Web.Api
{
    public class BaseApiController : ApiController
    {
        public NorthwindContext DataContext { get; private set; }

        public BaseApiController()
        {
            this.DataContext = new NorthwindContext();
        }
    }
}