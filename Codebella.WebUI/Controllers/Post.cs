using Codebella.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Codebella.WebUI.Controllers;

public class Post : Controller
{
    private readonly IArticleService _articleService;
    public Post(IArticleService articleService)
    {
        _articleService = articleService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _articleService.GetAllAsync();
        return View();
    }
}