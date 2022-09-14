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

namespace Codebella.Business.Concrete
{
    // TODO: ArticleManager / getComments ile devam edilecek.

    public class ArticleManager : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleManager(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<IResult> AddAsync(Article article)
        {
            try
            {
                await _articleRepository.Create(article);
                return new SuccessResult();
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public async Task<IResult> DeleteAsync(Article article)
        {
            try
            {
                await _articleRepository.Delete(article);
                return new SuccessResult();
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<Article>>> GetAllAsync(Expression<Func<Article, bool>> expression)
        {
            try
            {
                var data = await _articleRepository.GetAll(expression);
                return new SuccessDataResult<IEnumerable<Article>>(data);

            }
            catch (Exception e)
            {
                return new ErrorDataResult<IEnumerable<Article>>(e.Message, null);
            }
        }
        
        public async Task<IDataResult<IEnumerable<Article>>> GetAllAsync()
        {
            try
            {
                var data = await _articleRepository.GetAll();
                return new SuccessDataResult<IEnumerable<Article>>(data);

            }
            catch (Exception e)
            {
                return new ErrorDataResult<IEnumerable<Article>>(e.Message, null);
            }
        }

        public async Task<IDataResult<Article>> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await _articleRepository.Get(a => a.Id == id);
                return new SuccessDataResult<Article>(data);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Article>(e.Message, null);
            }
        }

        public async Task<IDataResult<IEnumerable<Comment>>> GetCommentsAsync(Article article)
        {
            try
            {
                Article current = await _articleRepository.Get(a => a.Id == article.Id);
                return new SuccessDataResult<IEnumerable<Comment>>(current.Comments);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<IEnumerable<Comment>>(e.Message, null);
            }
        }

        public async Task<IDataResult<int?>> GetLikeCountAsync(Article article)
        {
            try
            {
                Article current = await _articleRepository.Get(a => a.Id == article.Id);
                int likeCount = current != null ? current.Likes.Count() : 0;
                return new SuccessDataResult<int?>(likeCount);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<int?>(e.Message, null);
            }
        }

        public async Task<IResult> UpdateAsync(Article article)
        {
            try
            {
                await _articleRepository.Update(article);
                return new SuccessResult();
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
