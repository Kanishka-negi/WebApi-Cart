using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class MovieConsumed : Controller
    {
        private readonly ILogger<MovieConsumed> _logger;
        private readonly HttpClient _httpClient;

        public MovieConsumed(ILogger<MovieConsumed> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7213/api/Movie");
            response.EnsureSuccessStatusCode();

            var movies = await response.Content.ReadFromJsonAsync<MovieViewModel[]>();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7213/api/Movie/{id}");
            response.EnsureSuccessStatusCode();

            var movie = await response.Content.ReadFromJsonAsync<MovieViewModel>();
            return View(movie);
        }
    }
}
