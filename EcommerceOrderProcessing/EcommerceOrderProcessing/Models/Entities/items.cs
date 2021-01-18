using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceOrderProcessing.Models
{
    public class items
    {
        [Key]
        public string item_id { get; set; }
        public string item_name { get; set; }
    }
}
