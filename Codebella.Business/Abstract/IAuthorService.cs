using Codebella.Core.Utility.ResultType;
using Codebella.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Business.Abstract;

public interface IAuthorService
{
    Task<IResult> AddAsync(Author author);
    Task<IResult> UpdateAsync(Author author);
    Task<IResult> DeleteAsync(Author author);
    Task<IDataResult<Author>> GetByIdAsync(int authorId);
    Task<IDataResult<Author>> GetByNicknameAsync(string nickname);
    Task<IDataResult<IEnumerable<Author>>> GetAllAsync(Expression<Func<Author, bool>> predicate);
    Task<IDataResult<IEnumerable<Author>>> GetAllAsync();
    Task<IDataResult<IEnumerable<Article>>> GetArticlesById(int authorId);
}
