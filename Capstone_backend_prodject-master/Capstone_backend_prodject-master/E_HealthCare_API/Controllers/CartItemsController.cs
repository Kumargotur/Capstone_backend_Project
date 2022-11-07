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
    public class CartItemsController : ControllerBase
    {
        ApplicationDbContext _context;
        public CartItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpGet("GetcartItem")]
        public async Task<ActionResult<List<CartItem>>> GetUsers()
        {
            return await _context.CartItems.ToListAsync();
        }

        //Add items to cart
        [HttpPost("addtocart")]
        public async Task<ActionResult> AddtoCart(CartItem cart)
        {
            _context.CartItems.Add(cart);
            await _context.SaveChangesAsync();
            return Ok("Item Added to cart successfully.");
        }

        [Route("getcartitembyusers/{userid}")]
        [HttpGet]
        public async Task<ActionResult<List<CartItem>>> GetcartitembyUsers(int userid)
        {
            var user = await _context.CartItems.Where(a => a.UserID == userid).ToListAsync();
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        //Increment the items in Cart by 1
        [HttpPost("additemstocart/{productid}/{userid}")]
        public async Task<ActionResult> additemstocart(int productid,int userid)
        {
            var addmed = await _context.CartItems.Where(p => p.ProductID == productid && p.UserID == userid).FirstOrDefaultAsync();
            if(addmed == null)
            {
                CartItem cart = new CartItem();
                cart.UserID = userid;
                cart.ProductID = productid;
                cart.image = _context.Products.Find(productid).ImageUrl;
                cart.Qty = 1;
                cart.Amount = (decimal)_context.Products.Find(productid).Price;
                _context.CartItems.Add(cart);
            }
            else
            {
                addmed.Qty = addmed.Qty + 1;
                addmed.Amount = addmed.Amount+ (decimal)_context.Products.Find(productid).Price;
            }
            await _context.SaveChangesAsync();
            return Ok("Items Added successfully.");
        }

        [HttpPut("updateitemstocart")]
        public async Task<ActionResult> updateitemstocart(CartItem cart)
        {
            _context.CartItems.Update(cart);
            await _context.SaveChangesAsync();
            return Ok("Items Edited successfully.");

        }

        //Decrement the items in Cart by 1
        [HttpDelete("deleteitemfromcart/{productid}/{userid}")]
        public async Task<IActionResult> deleteitemfromcart(int productid,int userid)
        {
            var med = await _context.CartItems.Where(p=>p.ProductID==productid && p.UserID==userid).FirstOrDefaultAsync();
            if (med == null)
            {
                return NotFound();
            }
            if(med.Qty > 1)
            {
                med.Qty = med.Qty - 1;
                med.Amount = med.Amount - (decimal)_context.Products.Find(productid).Price;
                _context.CartItems.Update(med);
            }
            else
            {
                _context.CartItems.Remove(med);
            }
            await _context.SaveChangesAsync();
            return Ok("Items Deleted Successfully");

        }

        //Delete the item irrespective of Qty
        [HttpDelete("deleteitem/{productid}/{userid}")]
        public async Task<IActionResult> deleteitem(int productid, int userid)
        {
            var med = await _context.CartItems.Where(p => p.ProductID == productid && p.UserID == userid).FirstOrDefaultAsync();
            _context.CartItems.Remove(med);
            await _context.SaveChangesAsync();
            return Ok("Items Deleted Successfully");

        }

        [HttpDelete("Orderplacedsuccessfully/{userid}")]
        public async Task<IActionResult> Orderplacedsuccessfully(int userid)
        {
            var allcartitems = await _context.CartItems.Where(P=>P.UserID==userid).ToListAsync();
            if (allcartitems == null)
            {
                return NotFound();
            }
            for(int i=0;i< allcartitems.Count; i++)
            {
                _context.CartItems.Remove(allcartitems[i]);
            }
            await _context.SaveChangesAsync();
            return Ok("Items deleted once Order placed Successfully");

        }
    }
}
