using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceOrderProcessing.Models
{
    public class orders
    {
        [Key]
        public string order_id { get; set; }
        public string customer_id { get; set; }

        public float subtotal { get; set; }
        public float tax { get; set; }
        public float shipamount { get; set; }
        public float total { get; set; }
        public string status { get; set; }
        public string activeflag { get; set; }
    }
}
