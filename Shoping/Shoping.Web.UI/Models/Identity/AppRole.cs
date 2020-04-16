using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoping.Web.UI.Models.Identity
{
    public class AppRole:IdentityRole
    {
        public string RoleLevel { get; set; }

        public string Description { get; set; }
    }
}
