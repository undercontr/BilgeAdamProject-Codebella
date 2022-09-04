using Codebella.Business.Abstract;
using Codebella.Core.Utility.ResultType;
using Codebella.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Business.Concrete
{
    public class LikeManager : ILikeService
    {
        public Task<IResult> AddAsync(Like like)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(Like like)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<Like>>> GetAllAsync(Expression<Func<Like, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Like>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(Like like)
        {
            throw new NotImplementedException();
        }
    }
}
