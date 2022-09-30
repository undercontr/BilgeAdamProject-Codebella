using Codebella.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Codebella.WebUI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorManager;
        public AuthorController(IAuthorService authorManager)
        {
            _authorManager = authorManager;
        }

        [Route("{controller=Author}/@{nickname}")]
        public async Task<IActionResult> Index(string nickname)
        {
            var author = await _authorManager.GetByNicknameAsync(nickname);
            return View(author.Data);
        }
    }
}
