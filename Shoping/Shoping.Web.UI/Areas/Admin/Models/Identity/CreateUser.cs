using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shoping.Web.UI.Areas.Admin.Models.Identity
{
    public class CreateUser
    {


        public string Id { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicConst.EnterMessage)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = PublicConst.LengthMessage)]
        public string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicConst.EnterMessage)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = PublicConst.LengthMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicConst.EnterMessage)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = PublicConst.LengthMessage)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور با تکرار آن یکسان نیست")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "نام")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicConst.EnterMessage)]
        public string FirstName { get; set; }

        [Display(Name = "فامیلی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicConst.EnterMessage)]
        public string LastName { get; set; }

      

        [Display(Name = "تلفن")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicConst.EnterMessage)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره تماس 11 رقمی می باشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "شماره تماس شامل حرف نمی تواند باشد")]
        public string PhoneNumber { get; set; }

        [Display(Name = "ایمیل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicConst.EnterMessage)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicConst.EnterMessage)]
        public string[] idrole { get; set; }

    }
}
