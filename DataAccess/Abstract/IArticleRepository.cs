using Core.Entity.Abstract;
using Entity;

namespace DataAccess.Abstract;

public interface IArticleRepository : IBaseRepository<Article>
{
    Task<int> LikeCount(Article article);
    Task<ICollection<Comment>?> GetComments(Article article);
}