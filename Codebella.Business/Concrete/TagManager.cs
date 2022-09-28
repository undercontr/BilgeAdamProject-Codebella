using Codebella.Business.Abstract;
using Codebella.Core.Utility.ResultType;
using Codebella.DataAccess.Abstract;
using Codebella.Entity;
using Codebella.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Business.Concrete
{
    public class TagManager : ITagService
    {
        private readonly ITagRepository _tagRepository;
        public TagManager(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<IResult> AddAsync(Tag tag)
        {
            try
            {
                await _tagRepository.Create(tag);
                return new SuccessResult();
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public async Task<IResult> DeleteAsync(Tag tag)
        {
            try
            {
                await _tagRepository.Delete(tag);
                return new SuccessResult();
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<Tag>>> GetAllAsync(Expression<Func<Tag, bool>> predicate)
        {
            try
            {
                var data = await _tagRepository.GetAll(predicate);
                return new SuccessDataResult<IEnumerable<Tag>>(data);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<IEnumerable<Tag>>(e.Message, null);
            }
        }

        public async Task<IDataResult<IEnumerable<Tag>>> GetAllAsync()
        {
            try
            {
                var data = await _tagRepository.GetAll();
                return new SuccessDataResult<IEnumerable<Tag>>(data);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<IEnumerable<Tag>>(e.Message, null);
            }
        }

        public async Task<IDataResult<Tag>> GetByIdAsync(int tagId)
        {
            try
            {
                var data = await _tagRepository.Get(t => t.Id == tagId);
                return new SuccessDataResult<Tag>(data);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Tag>(e.Message, null);
            }
        }

        public async Task<IDataResult<Tag>> AddOrGetByNameAsync(string name)
        {
            var tag = await _tagRepository.Get(t => t.Name == name);

            if (tag != null)
            {
                return new SuccessDataResult<Tag>(tag);
            }

            var insertedTag = new Tag { Name = name, Slug = name.Slugify() };
            await _tagRepository.Create(insertedTag);
            return new SuccessDataResult<Tag>(insertedTag);

        }

        public async Task<IResult> UpdateAsync(Tag tag)
        {
            try
            {
                await _tagRepository.Update(tag);
                return new SuccessResult();
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
