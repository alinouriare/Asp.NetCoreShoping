﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoping.Web.UI.Areas.Admin.Models
{
    public class TreeViewNode
    {
        public string id { get; set; }

        public string parent { get; set; }

        public string text { get; set; }
    }
}
