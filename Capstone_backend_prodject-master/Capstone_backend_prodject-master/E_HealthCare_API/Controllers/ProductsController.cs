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
    public class ProductsController : ControllerBase
    {
        ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("addMedicine")]
        public async Task<ActionResult> AddMedicine(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok("Medicine Added successfully.");
        }

        [HttpPut("updateMedicine")]
        public async Task<ActionResult> UpdateMedicine(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return Ok("Medicine Edited successfully.");

        }

        [HttpGet("getAllMedicine")]
        public async Task<ActionResult<List<Product>>> GetMedicine()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("getMedicineById/{id}")]
        public async Task<ActionResult<Product>> GetMedicine(int id)
        {
            var med = await _context.Products.FindAsync(id);
            if(med==null)
            {
                return NotFound();
            }    
            return med;

        }

        [HttpDelete("deleteMedicineById/{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            var med = await _context.Products.FindAsync(id);
            if (med == null)
            {
                return NotFound();
            }
            _context.Products.Remove(med);
            await _context.SaveChangesAsync();
            return Ok("Medicine Deleted Successfully");

        }

        [HttpGet("search/{uses}")]
        public async Task<ActionResult<List<Product>>> SearchMedicineByDisease(string uses)
        {
            return  await _context.Products.Where(p => p.Uses == uses).ToListAsync();
           
        }
    }
}
