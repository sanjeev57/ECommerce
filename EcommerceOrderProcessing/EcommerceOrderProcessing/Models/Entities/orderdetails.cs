using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceOrderProcessing.Models
{
    public class orderdetails
    {
        [Key]
        public string orderdetail_id { get; set; }
        public string order_id { get; set; }
        public string item_id { get; set; }
        public int quantity { get; set; }
    }
}
