using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebAPI.Model;
using WebMVC.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly WebAPIContext _context;
        //private readonly IHttpContextAccessor _httpContext;

        public AccountController(WebAPIContext context)
        {
            _context = context;
            
        }
        [HttpPost("login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the user exists in the database
                var user = _context.Accounts.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {

                    return Ok("Login successful");
                }

                return BadRequest("Invalid email or password.");
            }

            return BadRequest("Invalid model data.");
        }

        //[HttpPost("login")]
        //public async Task<ActionResult<UserLoginResponse>> Login(LoginViewModel model)
        //{
        //    UserLoginResponse response = new UserLoginResponse();

        //    if (ModelState.IsValid)
        //    {
        //        // Check if the user exists in the database
        //        var user = _context.Accounts.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

        //        if (user != null)
        //        {
        //            response.data = user;
        //            _httpContext.HttpContext.Session.SetInt32("userId", user.UserId);

        //            return response;
        //        }

        //        return BadRequest("Invalid email or password.");
        //    }

        //    return BadRequest("Invalid model data.");
        //}

        [HttpPost("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var existingUser = _context.Accounts.FirstOrDefault(u => u.Email == model.Email);

                if (existingUser != null)
                {
                    return BadRequest("Email already exists.");
                }
                var newUser = new Account
                {
                    Email = model.Email,
                    Password = model.Password,
                    Username = model.Username
                };

                _context.Accounts.Add(newUser);
                _context.SaveChanges();


                return Ok("Registration successful");
            }

            return BadRequest("Invalid data");
        }
    }
}
      


   