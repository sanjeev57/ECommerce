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
    public class CreateOrderController : ControllerBase
    {

        DatabaseContext db;
        public CreateOrderController()
        {
            db = new DatabaseContext();
        }
        //POST api/<CreateOrder>/id
        [HttpPost("{id}")]
        public IActionResult Post(string id, [FromBody] OrderDisplayDetails o)
        {
            try
            {
                items item_record = db.items.Where(i => i.item_name.ToLower() == o.item_name.ToLower()).FirstOrDefault();
                orders order_record = new orders();
                order_record.order_id = o.order_id;
                order_record.customer_id = o.customer_id;
                order_record.subtotal = o.subtotal;
                order_record.tax = o.tax;
                order_record.shipamount = o.shipamount;
                order_record.total = o.total;
                order_record.status = "Delievered";
                order_record.activeflag = "0";
                orderdetails orderdetails_record = new orderdetails();
                orderdetails_record.order_id = o.order_id;
                orderdetails_record.orderdetail_id = "OD" + o.order_id.Substring(1);
                orderdetails_record.quantity = o.quantity;
                orderdetails_record.item_id = item_record.item_id;
                payment payment_record = new payment();
                payment_record.payment_id = "P" + o.order_id.Substring(1);
                payment_record.order_id = o.order_id;
                payment_record.payment_month = o.payment_month;
                payment_record.payment_date = o.payment_date;
                payment_record.payment_confirmation = o.payment_confirmation;
                payment_record.billingadress = o.payment_billingadress;
                payment_record.city = o.payment_city;
                payment_record.state = o.payment_state;
                payment_record.zip = o.payment_zip;
                shipping shipping_record = new shipping();
                shipping_record.shipping_id = "S" + o.order_id.Substring(1);
                shipping_record.order_id = o.order_id;
                shipping_record.shippingadress = o.shippingadress;
                shipping_record.shippingcity = o.shippingcity;
                shipping_record.shippingstate = o.shippingstate;
                shipping_record.shippingzip = o.shippingzip;

                db.orders.Add(order_record);
                db.SaveChanges();
                db.orderdetails.Add(orderdetails_record);
                db.SaveChanges();
                db.payment.Add(payment_record);
                db.SaveChanges();
                db.shipping.Add(shipping_record);
                db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        // POST api/<CreateOrder>
        [HttpPost]
        public IActionResult Post([FromBody] List<OrderDisplayDetails> orderrequested)
        {
            try
            {
                foreach (var o in orderrequested)
                {
                    items item_record = db.items.Where(i => i.item_name.ToLower() == o.item_name.ToLower()).FirstOrDefault();
                    orders order_record = new orders();
                    order_record.order_id = o.order_id;
                    order_record.customer_id = o.customer_id;
                    order_record.subtotal = o.subtotal;
                    order_record.tax = o.tax;
                    order_record.shipamount = o.shipamount;
                    order_record.total = o.total;
                    order_record.status = "Delievered";
                    order_record.activeflag = "0";
                    orderdetails orderdetails_record = new orderdetails();
                    orderdetails_record.order_id = o.order_id;
                    orderdetails_record.orderdetail_id = "OD" + o.order_id.Substring(1);
                    orderdetails_record.quantity = o.quantity;
                    orderdetails_record.item_id = item_record.item_id;
                    payment payment_record = new payment();
                    payment_record.payment_id = "P" + o.order_id.Substring(1);
                    payment_record.order_id = o.order_id;
                    payment_record.payment_month = o.payment_month;
                    payment_record.payment_date = o.payment_date;
                    payment_record.payment_confirmation = o.payment_confirmation;
                    payment_record.billingadress = o.payment_billingadress;
                    payment_record.city = o.payment_city;
                    payment_record.state = o.payment_state;
                    payment_record.zip = o.payment_zip;
                    shipping shipping_record = new shipping();
                    shipping_record.shipping_id = "S" + o.order_id.Substring(1);
                    shipping_record.order_id = o.order_id;
                    shipping_record.shippingadress = o.shippingadress;
                    shipping_record.shippingcity = o.shippingcity;
                    shipping_record.shippingstate = o.shippingstate;
                    shipping_record.shippingzip = o.shippingzip;

                    db.orders.Add(order_record);
                    db.SaveChanges();
                    db.orderdetails.Add(orderdetails_record);
                    db.SaveChanges();
                    db.payment.Add(payment_record);
                    db.SaveChanges();
                    db.shipping.Add(shipping_record);
                    db.SaveChanges();
                }
                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
           
        }

        // PUT api/<CreateOrder>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CreateOrder>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
