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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IResult> AddAsync(Category category)
        {
            try
            {
                await _categoryRepository.Create(category);
                return new SuccessResult();
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public async Task<IResult> DeleteAsync(Category category)
        {
            try
            {
                await _categoryRepository.Delete(category);
                return new SuccessResult();
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<Category>>> GetAllAsync(Expression<Func<Category, bool>> predicate)
        {
            try
            {
                var data = await _categoryRepository.GetAll(predicate);
                return new SuccessDataResult<IEnumerable<Category>>(data);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<IEnumerable<Category>>(e.Message, null);
            }
        }

        public async Task<IDataResult<IEnumerable<Article>>> GetArticlesById(Guid categoryId)
        {
            try
            {
                var data = await _categoryRepository.Get(c => c.Id == categoryId);
                //return new SuccessDataResult<IEnumerable<Article>>(data);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<IDataResult<Category>> GetByIdAsync(Guid categoryId)
        {
            try
            {
                var data = await _categoryRepository.Get(c => c.Id == categoryId);
                return new SuccessDataResult<Category>(data);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Category>(e.Message, null);
            }
        }

        public async Task<IResult> UpdateAsync(Category category)
        {
            try
            {
                await _categoryRepository.Update(category);
                return new SuccessResult();
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
