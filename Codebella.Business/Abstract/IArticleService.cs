using Codebella.Core.Utility.ResultType;
using Codebella.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Business.Abstract;

public interface IArticleService
{
    Task<IResult> AddAsync(Article article);
    Task<IResult> UpdateAsync(Article article);
    Task<IResult> DeleteAsync(Article article);
    Task<IDataResult<Article>> GetByIdAsync(Guid id);
    Task<IDataResult<IEnumerable<Article>>> GetAllAsync(Expression<Func<Article, bool>> predicate);
    Task<IDataResult<IEnumerable<Article>>> GetAllAsync();
    Task<IDataResult<int?>> GetLikeCountAsync(Article article);
    Task<IDataResult<IEnumerable<Comment>>> GetCommentsAsync(Article article);
}
