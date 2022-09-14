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
    public interface ITagService
    {
        Task<IResult> AddAsync(Tag tag);
        Task<IResult> UpdateAsync(Tag tag);
        Task<IResult> DeleteAsync(Tag tag);
        Task<IDataResult<Tag>> GetByIdAsync(Guid tagId);
        Task<IDataResult<IEnumerable<Tag>>> GetAllAsync(Expression<Func<Tag, bool>> predicate);
        Task<IDataResult<IEnumerable<Tag>>> GetAllAsync();
    }
}
