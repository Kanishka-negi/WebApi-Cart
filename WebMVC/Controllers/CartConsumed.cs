using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebMVC.Models;


namespace WebMVC.Controllers
{
    public class CartConsumed : Controller
    {
        private readonly ILogger<CartConsumed> _logger;
        private readonly HttpClient _httpClient;



        public CartConsumed(ILogger<CartConsumed> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;

        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string movieId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Register", "AccountConsumed");
            }
            List<CartViewModel> cartItems = new List<CartViewModel>();



            var cartItem = new CartViewModel
            {
                UserId = userId.Value,
                MovieId = int.Parse(movieId),
                Quantity = 1,
                //Quantity = quantity,




            };

            var response = await _httpClient.GetAsync($"https://localhost:7213/api/Movie/{cartItem.MovieId}");
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to retrieve the movie details.");
                return View(cartItem);
            }

            var movie = await response.Content.ReadFromJsonAsync<MovieViewModel>();
            if (movie == null)
            {
                ModelState.AddModelError("", "Movie not found.");
                return View(cartItem);
            }


            cartItem.Price = movie.Price;
            cartItem.Name = movie.Name;
            //cartItem.Quantity = movie.Quantity;
            cartItem.TotalPrice = movie.Price * cartItem.Quantity;


            var content = new StringContent(JsonSerializer.Serialize(cartItem), Encoding.UTF8, "application/json");
            response = await _httpClient.PostAsync("https://localhost:7213/api/Cart", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "MovieConsumed");
            }

            ModelState.AddModelError("", "Failed to add the movie to the cart.");

            return View(cartItem);
        }
    }
}



































