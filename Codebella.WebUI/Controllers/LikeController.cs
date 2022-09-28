using Codebella.Business.Abstract;
using Codebella.Entity;
using Codebella.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Codebella.WebUI.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILikeService _likeManager;
        public LikeController(ILikeService likeManager)
        {
            _likeManager = likeManager;
        }
        public async Task<IActionResult> AddLike(Like like)
        {
            if (User.Identity.IsAuthenticated)
            {
                var result = await _likeManager.AddAsync(like);    
                if (result.Success)
                {
                    this.FlashSuccess("You liked the article!");
                    return Ok();
                } else
                {
                    this.FlashError("Error on like process!");
                    return BadRequest();
                }
            }

            return BadRequest();
        }
        public async Task<IActionResult> RemoveLike(Like like)
        {
            if (User.Identity.IsAuthenticated)
            {
                var likeResult = await _likeManager.GetByOwnerArticleId(like.ArticleId, like.OwnerId);

                if (likeResult.Success)
                {
                    if (likeResult.Data != null)
                    {
                        var deleteResult = await _likeManager.DeleteAsync(likeResult.Data);

                        if (deleteResult.Success)
                        {
                            this.FlashSuccess("Like successfully reverted!");
                            return Ok();
                        }
                    }
                }
            }
            this.FlashError("Error reverting like process!");
            return BadRequest();
        }
    }
}
