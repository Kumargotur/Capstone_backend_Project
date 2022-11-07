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
    public class AccountsController : ControllerBase
    {
        ApplicationDbContext _context;
        public AccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("accountInfo/{email}")]
        public async Task<ActionResult<Account>> getAccountDetails(String email)
        {
           var accountinfo=await _context.Accounts.Where(a => a.Email == email).FirstOrDefaultAsync();
            if(accountinfo == null)
            {
                return NotFound();
            }
            return accountinfo;
        }

        [HttpPut("addFunds")]
        public async Task<ActionResult<Account>> AddFunds([FromBody] Account account)
        {
            var result = await _context.Accounts.Where(a => a.Email == account.Email).AsNoTracking().FirstOrDefaultAsync();
            if(result==null)
            {
                return NotFound();
            }
            account.Amount = result.Amount + account.Amount;

            var updated = _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
