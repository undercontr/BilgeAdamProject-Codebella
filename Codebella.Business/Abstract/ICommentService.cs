using Codebella.Core.Utility.ResultType;
using Codebella.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Business.Abstract;

public interface ICommentService
{
    Task<IResult> AddAsync(Comment comment);
    Task<IResult> UpdateAsync(Comment comment);
    Task<IResult> DeleteAsync(Comment comment);
    Task<IDataResult<Comment>> GetById(Guid commentId);
    Task<IDataResult<IEnumerable<Comment>>> GetAllAsync(Expression<Func<Comment, bool>> predicate);
}
