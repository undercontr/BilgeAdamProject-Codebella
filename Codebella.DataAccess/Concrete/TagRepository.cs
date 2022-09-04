using System.Diagnostics;
using Codebella.Core.Entity.Concrete;
using Codebella.Entity;
using Microsoft.EntityFrameworkCore;
using Codebella.DataAccess.Abstract;
using Codebella.DataAccess.Context;

namespace Codebella.DataAccess.Concrete;

public class TagRepository : BaseRepository<Tag, BlogContext>, ITagRepository
{
    public TagRepository(BlogContext context) : base(context)
    {
    }
}