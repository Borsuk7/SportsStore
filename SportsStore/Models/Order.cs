using Microsoft.AspNetCore.Mvc.ModelBinding;
using SportsStore.Models.Carts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int ID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [BindNever]
        public bool Shipped { get; set; }

        [Required(ErrorMessage = "Please enter а name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public string Address { get; set; }    

        [Required(ErrorMessage = "Please enter а city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter а country name")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
