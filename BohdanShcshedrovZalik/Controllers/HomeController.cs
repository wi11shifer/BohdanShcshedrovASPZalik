using BohdanShcshedrovZalik.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BohdanShcshedrovZalik.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                ViewBag.Message = "Please enter a valid string.";
                ViewBag.Result = new int[] { };
            }
            else
            {
                var letters = FindCapitalLetters(input);
                ViewBag.Message = $"Input string: {input}";
                ViewBag.Result = letters;
            }

            return View();
        }

        private int[] FindCapitalLetters(string input)
        {
            var letters = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                {
                    letters.Add(i);
                }
            }
            return letters.ToArray();
        }
    }
}
