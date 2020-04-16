using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoping.Web.UI.Infrastructures
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request)
        =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" :
                request.Path.ToString();

        
    }
}
