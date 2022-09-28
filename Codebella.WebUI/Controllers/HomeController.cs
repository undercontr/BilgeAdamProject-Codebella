using Codebella.Business.Abstract;
using Codebella.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Codebella.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleManager;

        public HomeController(ILogger<HomeController> logger, IArticleService articleManager)
        {
            _logger = logger;
            _articleManager = articleManager;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _articleManager.GetAllAsync();
            return View(result.Data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}