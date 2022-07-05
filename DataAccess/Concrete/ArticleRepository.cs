using System.Diagnostics;
using Core.Entity.Concrete;
using Entity;
using Microsoft.EntityFrameworkCore;
using DataAccess.Abstract;
using DataAccess.Context;

namespace DataAccess.Concrete;

public class ArticleRepository : BaseRepository<Article, BlogContext>, IArticleRepository
{
    private readonly BlogContext _context;

    public ArticleRepository(BlogContext context) : base(context)
    {
        _context = context;
    }
}