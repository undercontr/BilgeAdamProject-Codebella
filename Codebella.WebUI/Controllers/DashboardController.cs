using AutoMapper;
using Codebella.Business.Abstract;
using Codebella.DTOs;
using Codebella.Entity;
using Codebella.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Codebella.WebUI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IAuthorService _authorManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public DashboardController(IAuthorService authorManager, UserManager<User> userManager, IMapper mapper)
        {
            _authorManager = authorManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var author = await _userManager.GetAuthorByUserEmailAsync(User.Identity.Name);
            var data = await _authorManager.GetByIdAsync(author.Id);

            var modelData = _mapper.Map<IEnumerable<DashboardArticleDto>>(data.Data.Articles);
            return View(new DashboardIndexDto { Articles = modelData});
        }
    }
}
