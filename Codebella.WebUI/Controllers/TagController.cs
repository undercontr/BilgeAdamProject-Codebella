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
    public class TagController : Controller
    {
        private readonly ITagService _tagManager;
        private readonly IArticleService _articleManager;
        private readonly ILikeService _likeManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public TagController(ITagService tagManager, IArticleService articleManager, ILikeService likeManager, IMapper mapper, UserManager<User> userManager)
        {
            _tagManager = tagManager;
            _articleManager = articleManager;
            _userManager = userManager;
            _likeManager = likeManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await _tagManager.GetAllAsync();
            return View(tags.Data.Where(c => c.Articles.Any()));
        }

        [Route("{controller=Tag}/{slug}")]
        public async Task<IActionResult> Tag(string slug)
        {
            var tag = await _tagManager.GetBySlugAsync(slug);
            return View("Tag", tag.Data);
        }
    }
}
