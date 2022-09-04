using System.Diagnostics;
using Codebella.Core.Entity.Concrete;
using Codebella.Entity;
using Microsoft.EntityFrameworkCore;
using Codebella.DataAccess.Abstract;
using Codebella.DataAccess.Context;

namespace Codebella.DataAccess.Concrete;

public class CommentRepository : BaseRepository<Comment, BlogContext>, ICommentRepository
{
    public CommentRepository(BlogContext context) : base(context)
    {
    }
}