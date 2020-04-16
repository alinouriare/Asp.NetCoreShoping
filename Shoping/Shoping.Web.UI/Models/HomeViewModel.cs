using Shoping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoping.Web.UI.Models
{
    public class HomeViewModel
    {

        public string Category { get; set; }

        public PagedResult<Product> Result { get; set; } = new PagedResult<Product>();
    }
}
