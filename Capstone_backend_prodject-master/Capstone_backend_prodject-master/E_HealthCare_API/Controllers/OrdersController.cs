using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_HealthCare_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_HealthCare_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        ApplicationDbContext _context;
        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("orders")]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }


        [HttpGet("orders/{userid}")]
        public async Task<ActionResult<List<Order>>> GetOrdersbyuser(int userid)
        {
            var orders = await _context.Orders.Where(a => a.UserID == userid).ToListAsync();
            if (orders == null)
            {
                return NotFound();
            }
            return orders;
        }

        [HttpPost("Addtoorders")]
        public async Task<ActionResult> addtoorders(List<CartItem> cart)
        {
            Random rand = new Random();
            int order_number = rand.Next();

            foreach(var item in cart)
            {
                Order order = new Order();
                order.UserID = item.UserID;
                order.Amount = item.Amount;
                order.PlacedOn = DateTime.Now;
                order.OrderStatus = "Ordered";
                order.ProductID = item.ProductID;
                order.Qty = item.Qty;
                order.ordernumber = order_number;
                order.image = item.image;

                var itemid = _context.Products.Find(item.ProductID);
                itemid.Quantity = itemid.Quantity - item.Qty;
               _context.Orders.Add(order);
            }
            await _context.SaveChangesAsync();
            return Ok("Order Placed successfully");
        }
    }
}
