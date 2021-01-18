using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceOrderProcessing.Models
{
    public class OrderDisplayDetails
    {
        public string order_id { get; set; }
        public string customer_id { get; set; }

        public float subtotal { get; set; }
        public float tax { get; set; }
        public float shipamount { get; set; }
        public float total { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
        public string item_name { get; set; }
        public string payment_month { get; set; }
        public string payment_date { get; set; }
        public string payment_confirmation { get; set; }
        public string payment_billingadress { get; set; }
        public string payment_city { get; set; }
        public string payment_state { get; set; }
        public string payment_zip { get; set; }
        public string shippingadress { get; set; }
        public string shippingcity { get; set; }
        public string shippingstate { get; set; }
        public string shippingzip { get; set; }
    }
}
