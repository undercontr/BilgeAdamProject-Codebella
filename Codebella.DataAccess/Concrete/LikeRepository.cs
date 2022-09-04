using System.Diagnostics;
using Codebella.Core.Entity.Concrete;
using Codebella.Entity;
using Microsoft.EntityFrameworkCore;
using Codebella.DataAccess.Abstract;
using Codebella.DataAccess.Context;

namespace Codebella.DataAccess.Concrete;

public class LikeRepository : BaseRepository<Like, BlogContext>, ILikeRepository
{
    public LikeRepository(BlogContext context) : base(context)
    {
    }
}