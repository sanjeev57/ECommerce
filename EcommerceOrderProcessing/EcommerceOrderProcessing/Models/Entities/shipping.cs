using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceOrderProcessing.Models
{
    public class shipping
    {
        [Key]
        public string shipping_id { get; set; }
        public string order_id { get; set; }
        public string shippingadress { get; set; }
        public string shippingcity { get; set; }
        public string shippingstate { get; set; }
        public string shippingzip { get; set; }
    }
}
