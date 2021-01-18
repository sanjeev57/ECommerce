using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceOrderProcessing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceOrderProcessing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateOrderStatusController : ControllerBase
    {
        DatabaseContext db;
        public UpdateOrderStatusController()
        {
            db = new DatabaseContext();
        }
        // PUT api/<UpdateOrderStatusController>/5
        [HttpPut]
        public IActionResult Put([FromBody] List<OrderStatus> os_list)
        {
            try
            {
                foreach(var os in os_list)
                {
                    orders o = db.orders.Find(os.order_id);
                    o.status = os.status;
                    db.SaveChanges();
                }
               
                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
