using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebMVC.Controllers
{
    public class AccountConsumed : Controller
    {
        private readonly ILogger<AccountConsumed> _logger;
        private readonly HttpClient _httpClient;

        public AccountConsumed(ILogger<AccountConsumed> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7213/api/Account/login", content);

                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("UserId", model.Email);
                    return RedirectToAction("Index", "MovieConsumed");
                }

                ModelState.AddModelError("", "Invalid email or password.");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]



        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7213/api/Account/register", content);

                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("UserId", model.Email);
                    return RedirectToAction("Login","AccountConsumed");
                }

                ModelState.AddModelError("", "Failed to register.");
            }

            return View(model);
        }
    }
}



