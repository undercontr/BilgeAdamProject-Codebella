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

    public async Task<int> LikeCount(Article article)
    {
        Article? current = await _context.Set<Article>().FirstOrDefaultAsync(a => a.Id == article.Id);
        return current != null ? current.Likes.Count : 0;
    }

    public async Task<ICollection<Comment>?> GetComments(Article article)
    {
        Article? current = await _context.Set<Article>().FirstOrDefaultAsync(a => a.Id == article.Id);
        return current?.Comments;
    }
}