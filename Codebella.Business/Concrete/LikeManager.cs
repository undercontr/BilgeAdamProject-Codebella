﻿using Codebella.Business.Abstract;
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
    public class LikeManager : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeManager(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<IResult> AddAsync(Like like)
        {
            try
            {
                await _likeRepository.Create(like);
                return new SuccessResult();
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public async Task<IResult> DeleteAsync(Like like)
        {
            try
            {
                await _likeRepository.Delete(like);
                return new SuccessResult();
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<Like>>> GetAllAsync(Expression<Func<Like, bool>> predicate)
        {
            try
            {
                var data = await _likeRepository.GetAll(predicate);
                return new SuccessDataResult<IEnumerable<Like>>(data);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<IEnumerable<Like>>(e.Message, null);
            }
        }
        
        public async Task<IDataResult<IEnumerable<Like>>> GetAllAsync()
        {
            try
            {
                var data = await _likeRepository.GetAll();
                return new SuccessDataResult<IEnumerable<Like>>(data);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<IEnumerable<Like>>(e.Message, null);
            }
        }

        public async Task<IDataResult<Like>> GetByIdAsync(int id)
        {
            try
            {
                var data = await _likeRepository.Get(l => l.Id == id);
                return new SuccessDataResult<Like>(data);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Like>(e.Message, null);
            }
        }
        public async Task<IDataResult<Like>> GetByOwnerArticleId(int articleId, int userId)
        {
            try
            {
                var data = await _likeRepository.Get(l => l.OwnerId == userId && l.ArticleId == articleId);
                return new SuccessDataResult<Like>(data);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Like>(e.Message, null);
            }
        }
        public async Task<IDataResult<bool>> IsLiked(int articleId, int userId)
        {
            try
            {
                var data = await GetByOwnerArticleId(articleId, userId);

                if (data.Data != null)
                {
                    return new SuccessDataResult<bool>(true);
                } else
                {
                    return new SuccessDataResult<bool>(false);
                }
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(e.Message, false);
            }
        }

        public async Task<IResult> UpdateAsync(Like like)
        {
            try
            {
                await _likeRepository.Update(like);
                return new SuccessResult();
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
