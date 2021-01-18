using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceOrderProcessing.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceOrderProcessing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetOrderByIDController : ControllerBase
    {
        DatabaseContext db;
        public GetOrderByIDController()
        {
            db = new DatabaseContext();
        }
        // GET: api/<OrderProcessingController>
        [HttpGet]
        public IEnumerable<orders> Get()
        {
            return db.orders.ToList();
        }

        // GET api/<GetOrderByIDController>/O1
        [HttpGet("{id}")]
        public OrderDisplayDetails Get(string id)
        {
            //Details fetch
            orders order_record = db.orders.Find(id);
            orderdetails orderdetail_record = db.orderdetails.Where(o => o.order_id == id).FirstOrDefault();
            items item_record = db.items.Find(orderdetail_record.item_id);
            payment payment_record = db.payment.Where(p => p.order_id == id).FirstOrDefault();
            shipping shipping_record = db.shipping.Where(s => s.order_id == id).FirstOrDefault();

            OrderDisplayDetails o_details = new OrderDisplayDetails();
            o_details.order_id = order_record.order_id;
            o_details.customer_id = order_record.customer_id;
            o_details.subtotal = order_record.subtotal;
            o_details.tax = order_record.tax;
            o_details.shipamount = order_record.shipamount;
            o_details.total = order_record.total;
            o_details.status = order_record.status;
            o_details.quantity = orderdetail_record.quantity;
            o_details.item_name = item_record.item_name;
            o_details.payment_month = payment_record.payment_month;
            o_details.payment_date = payment_record.payment_date;
            o_details.payment_confirmation = payment_record.payment_confirmation;
            o_details.payment_billingadress = payment_record.billingadress;
            o_details.payment_city = payment_record.city;
            o_details.payment_state = payment_record.state;
            o_details.payment_zip = payment_record.zip;
            o_details.shippingadress = shipping_record.shippingadress;
            o_details.shippingcity = shipping_record.shippingcity;
            o_details.shippingstate = shipping_record.shippingstate;
            o_details.shippingzip = shipping_record.shippingzip;

            return o_details;
        }
    }
}
