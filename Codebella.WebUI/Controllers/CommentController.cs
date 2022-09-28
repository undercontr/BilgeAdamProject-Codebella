using Codebella.Business.Abstract;
using Codebella.Entity;
using Codebella.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Codebella.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentManager;
        public CommentController(ICommentService commentManager)
        {
            _commentManager = commentManager;
        }

        public async Task<IActionResult> AddComment(Comment comment)
        {
            var commentAddResult = await _commentManager.AddAsync(comment);

            if (commentAddResult.Success)
            {
                this.FlashSuccess("Comment added successfully!");
                return Ok();
            }
            return BadRequest();
        }

        public async Task<IActionResult> RemoveComment(int commentId)
            {
            var commentResult = await _commentManager.GetById(commentId);

            if (commentResult.Success)
            {
                if (User.Identity.Name == commentResult.Data.User.Email)
                {
                    var removeResult = await _commentManager.DeleteAsync(commentResult.Data);

                    if (removeResult.Success)
                    {
                        this.FlashSuccess("Comment removed successfully!");
                        return Ok();
                    }
                } else
                {
                    this.FlashError("Only the owner of the comment can remove this comment!");
                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
