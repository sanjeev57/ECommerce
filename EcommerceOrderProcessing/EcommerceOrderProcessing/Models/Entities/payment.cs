using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceOrderProcessing.Models
{
    public class payment
    {
        [Key]
        public string payment_id { get; set; }
        public string order_id { get; set; }
        public string payment_month { get; set; }
        public string payment_date { get; set; }
        public string payment_confirmation { get; set; }
        public string billingadress { get; set; }
        public string city { get; set; }
        public string state { get; set;}
        public string zip { get; set; }
    }
}
