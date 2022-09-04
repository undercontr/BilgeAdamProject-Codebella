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
    public interface ICategoryService
    {
        Task<IResult> AddAsync(Category category);
        Task<IResult> UpdateAsync(Category category);
        Task<IResult> DeleteAsync(Category category);
        Task<IDataResult<Category>> GetByIdAsync(Guid categoryId);
        Task<IDataResult<IEnumerable<Category>>> GetAllAsync(Expression<Func<Category, bool>> predicate);
        Task<IDataResult<IEnumerable<Article>>> GetArticlesById(Guid categoryId);
    }
}
