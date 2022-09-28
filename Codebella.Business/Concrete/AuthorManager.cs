using Codebella.Business.Abstract;
using Codebella.Core.Utility.ResultType;
using Codebella.DataAccess.Abstract;
using Codebella.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Business.Concrete;

public class AuthorManager : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    public AuthorManager(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IResult> AddAsync(Author author)
    {
        try
        {
            await _authorRepository.Create(author);
            return new SuccessResult();
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }

    public async Task<IResult> DeleteAsync(Author author)
    {
        try
        {
            await _authorRepository.Delete(author);
            return new SuccessResult();
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }

    public async Task<IDataResult<IEnumerable<Author>>> GetAllAsync(Expression<Func<Author, bool>> predicate)
    {
        try
        {
            var data = await _authorRepository.GetAll(predicate);
            return new SuccessDataResult<IEnumerable<Author>>(data);
        }
        catch (Exception e)
        {
            return new ErrorDataResult<IEnumerable<Author>>(e.Message, null);
        }
    }
    
        public async Task<IDataResult<IEnumerable<Author>>> GetAllAsync()
        {
            try
            {
                var data = await _authorRepository.GetAll();
                return new SuccessDataResult<IEnumerable<Author>>(data);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<IEnumerable<Author>>(e.Message, null);
            }
        }


    public async Task<IDataResult<IEnumerable<Article>>> GetArticlesById(int authorId)
    {
        try
        {
            var author = await _authorRepository.Get(a => a.Id == authorId);
            return new SuccessDataResult<IEnumerable<Article>>(author.Articles);
        }
        catch (Exception e)
        {
            return new ErrorDataResult<IEnumerable<Article>>(e.Message, null);
        }
    }

    public async Task<IDataResult<Author>> GetByIdAsync(int authorId)
    {
        try
        {
            var data = await _authorRepository.Get(a => a.Id == authorId);
            return new SuccessDataResult<Author>(data);
        }
        catch (Exception e)
        {
            return new ErrorDataResult<Author>(e.Message, null);
        }
    }

    public async Task<IResult> UpdateAsync(Author author)
    {
        try
        {
            await _authorRepository.Update(author);
            return new SuccessResult();
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }
}
