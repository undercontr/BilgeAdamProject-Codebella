using AutoMapper;
using Codebella.DTOs;
using Codebella.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.AutoMapperTier
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Article, EditArticleDto>().ReverseMap();
            CreateMap<Article, SingleArticleDto>().ReverseMap();

            CreateMap<Article, DashboardArticleDto>().ForMember(
                m => m.Tags,
                m => m.MapFrom(
                    a => string.Join(", ", a.Tags.ToList().ConvertAll(t => t.Name))
                    )
                ).ReverseMap();
        }

    }
}
