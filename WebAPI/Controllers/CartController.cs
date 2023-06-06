using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebAPI.Model;
using WebMVC.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly WebAPIContext _context;
        //private readonly IHttpContextAccessor _httpContext;

        public CartController(WebAPIContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> AddToCart(CartViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == model.UserId && c.MovieId == model.MovieId);

                if (existingCart != null)
                {
                    existingCart.Quantity += model.Quantity;
                }
                else
                {
                    var cartItem = new Cart
                    {
                        UserId = model.UserId,
                        MovieId = model.MovieId,
                        Quantity = model.Quantity,
                        Price = model.Price,
                        Name = model.Name



                    };
                    _context.Carts.Add(cartItem);
                }

                await _context.SaveChangesAsync();

                return Ok("Movie added to cart successfully");
            }

            return BadRequest("Invalid model data.");
        }
    }
}









