using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shoping.Web.UI.Areas.Admin.Models.Identity
{
    public class CreateRole
    {

        [Display(Name = "عنوان نقش انگلیسی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicConst.EnterMessage)]
        public string Name { get; set; }

        [Display(Name = "نام بخش")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicConst.EnterMessage)]
        public string Description { get; set; }

        [Display(Name = "زیردسته ها")]
        public string RoleLevel { get; set; }
    }
}
