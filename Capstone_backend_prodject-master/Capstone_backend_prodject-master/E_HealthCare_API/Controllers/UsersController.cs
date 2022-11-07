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
    public class UsersController : ControllerBase
    {
        ApplicationDbContext _context;
        public UsersController (ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("getusers")]
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return  await _context.Users.ToListAsync();
        }

        [Route("getusersbyid/{id}")]
        [HttpGet]
        public async Task<ActionResult<User>> GetUsersbyId(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [Route("getusers/{email}")]
        [HttpGet]
        public async Task<ActionResult<User>> GetUsers(string email)
        {
            var user =await _context.Users.Where(a => a.Email == email).FirstOrDefaultAsync();
            if(user==null)
            {
                return NotFound();
            }
            return user;
        }

        [Route("Signup")]
        [HttpPost]  
        //User Registration
        public async Task<ActionResult> PostUsers(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User Added Successfully. Please proceed to login");
        }


        [Route("Login/{email}/{password}")]
        [HttpGet]
        //Login 
        public async Task<ActionResult> LoginUser(string email,string password)
        {
            var getuser = await _context.Users.Where(P => P.Email == email).FirstOrDefaultAsync();
            if(getuser == null)
            {
                return Ok("User Does Not Exists");
            }
            if(getuser.Password!=password)
            {
                return Ok("Invalid Credentials");
            }

            return Ok("Logged In Successfully");
        }

        [Route("EditUser")]
        [HttpPut]
        //Edit Users
        public async Task<ActionResult> EditUsers(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return Ok("User Edited Successfully");
        }

        [Route("AddFunds/{userid}/{funds}")]
        [HttpPut]
        //EditAdd Funds
        public async Task<ActionResult> AddFunds(int userid, double funds)
        {
            var user= await _context.Users.Where(P => P.UserId == userid).FirstOrDefaultAsync();
            if (user == null)
            {
                return Ok("User Does Not Exists");
            }
            else
            {
                user.funds = user.funds + funds;
            }
            await _context.SaveChangesAsync();
            return Ok("Funds Added Successfully");
        }

        [Route("EditFunds/{userid}/{funds}")]
        [HttpPut]
        //EditAdd Funds
        public async Task<ActionResult> EditFunds(int userid, double funds)
        {
            var user = await _context.Users.Where(P => P.UserId == userid).FirstOrDefaultAsync();
            if (user == null)
            {
                return Ok("User Does Not Exists");
            }
            else
            {
                if(user.funds >= funds)
                {
                    user.funds = user.funds - funds;
                }
                else
                {
                    return Ok("Insufficient funds. Please add funds to proceed");
                }
                
            }
            await _context.SaveChangesAsync();
            return Ok("Funds updated  Successfully");
        }


    }
}
