using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shoping.Domain.Entities
{
  public  class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the first address line")]
        [MaxLength(200)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a city name")]
        [MaxLength(100)]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state name")]
        [MaxLength(100)]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter phone number")]
        [MaxLength(20)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter a country name")]
        [MaxLength(100)]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
        [MaxLength(100)]
        public string PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool Shipped { get; set; }
    }
}
