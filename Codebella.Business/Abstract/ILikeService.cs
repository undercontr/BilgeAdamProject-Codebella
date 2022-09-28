using Codebella.Core.Utility.ResultType;
using Codebella.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Business.Abstract
{
    public interface ILikeService
    {
        Task<IResult> AddAsync(Like like);
        Task<IResult> UpdateAsync(Like like);
        Task<IResult> DeleteAsync(Like like);
        Task<IDataResult<Like>> GetByIdAsync(int id);
        Task<IDataResult<Like>> GetByOwnerArticleId(int articleId, int userId);
        Task<IDataResult<bool>> IsLiked(int articleId, int userId);
        Task<IDataResult<IEnumerable<Like>>> GetAllAsync(Expression<Func<Like, bool>> predicate);
        Task<IDataResult<IEnumerable<Like>>> GetAllAsync();
    }
}
