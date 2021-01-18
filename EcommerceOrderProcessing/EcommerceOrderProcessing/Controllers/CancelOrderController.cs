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
    public class CancelOrderController : ControllerBase
    {
        DatabaseContext db;
        public CancelOrderController()
        {
            db = new DatabaseContext();
        }

        // PUT api/<CancelOrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id)
        {
            try
            {
                orders o = db.orders.Find(id);
                o.activeflag = "1";
                o.status = "Order Cancelled";
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }


        }

        // DELETE api/<CancelOrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
