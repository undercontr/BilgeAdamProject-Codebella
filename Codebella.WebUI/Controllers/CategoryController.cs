using Codebella.Business.Abstract;
using Codebella.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Codebella.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryManager;
        private readonly IArticleService _articleManager;

        public CategoryController(ICategoryService categoryManager, IArticleService articleManager)
        {
            _categoryManager = categoryManager;
            _articleManager = articleManager;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryManager.GetAllAsync();
            return View(categories.Data);
        }

        [Route("{controller=Category}/{slug}")]
        public async Task<IActionResult> Category(string slug)
        {
            var category = await _categoryManager.GetBySlugAsync(slug);
            return View("Category", category.Data);
        }

        [Route("{controller=Category}/{categorySlug}/{articleSlug?}")]
        public async Task<IActionResult> CategoryArticle(string categorySlug, string articleSlug)
        {
            var result = await _categoryManager.GetBySlugAsync(categorySlug);
            var article = result.Data.Articles.FirstOrDefault(a => a.Slug == articleSlug);
            if (article != null)
            {
                return View("SingleArticle", article);
            } else
            {
                this.FlashError("Article couldn't be brought");
                return RedirectToAction("Index");
            }
            
        }
    }
}
