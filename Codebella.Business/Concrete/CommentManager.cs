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

public class CommentManager : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    public CommentManager(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<IResult> AddAsync(Comment comment)
    {
        try
        {
            await _commentRepository.Create(comment);
            return new SuccessResult();
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }

    public async Task<IResult> DeleteAsync(Comment comment)
    {
        try
        {
            await _commentRepository.Delete(comment);
            return new SuccessResult();
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }

    public async Task<IDataResult<IEnumerable<Comment>>> GetAllAsync(Expression<Func<Comment, bool>> predicate)
    {
        try
        {
            var data = await _commentRepository.GetAll(predicate);
            return new SuccessDataResult<IEnumerable<Comment>>(data);
        }
        catch (Exception e)
        {
            return new ErrorDataResult<IEnumerable<Comment>>(e.Message, null);
        }
    }

    public async Task<IDataResult<Comment>> GetById(Guid commentId)
    {
        try
        {
            var data = await _commentRepository.Get(c => c.Id == commentId);
            return new SuccessDataResult<Comment>(data);
        }
        catch (Exception e)
        {
            return new ErrorDataResult<Comment>(e.Message, null);
        }
    }

    public async Task<IResult> UpdateAsync(Comment comment)
    {
        try
        {
            await _commentRepository.Update(comment);
            return new SuccessResult();
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }
}
