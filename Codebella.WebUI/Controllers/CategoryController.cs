using AutoMapper;
using Codebella.Business.Abstract;
using Codebella.DTOs;
using Codebella.Entity;
using Codebella.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Codebella.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryManager;
        private readonly IArticleService _articleManager;
        private readonly ILikeService _likeManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryManager, IArticleService articleManager, ILikeService likeManager, IMapper mapper, UserManager<User> userManager)
        {
            _categoryManager = categoryManager;
            _articleManager = articleManager;
            _userManager = userManager;
            _likeManager = likeManager;
            _mapper = mapper;
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
                var articleDto = _mapper.Map<SingleArticleDto>(article);
                articleDto.LikeCount = (await _articleManager.GetLikeCountAsync(article)).Data;

                if (User.Identity.IsAuthenticated)
                {
                    var currentUser = await _userManager.GetUserAsync(HttpContext.User);

                    articleDto.ArticleUserEmail = article.Author.User.Email;
                    articleDto.UserId = currentUser.Id;
                    articleDto.IsLiked = (await _likeManager.IsLiked(articleDto.Id, currentUser.Id)).Data;
                    
                    if (article.Author.Id == currentUser.Author.Id)
                    {
                        articleDto.IsMyArticle = true;
                    }

                    foreach (var comment in articleDto.Comments)
                    {
                        if (comment.UserEmail == User.Identity.Name)
                        {
                            comment.IsMyComment = true;
                        }
                    }
                }


                return View("SingleArticle", articleDto);
            } else
            {
                this.FlashError("Article couldn't be brought");
                return RedirectToAction("Index");
            }
            
        }
    }
}
