using Codebella.Business.Abstract;
using Codebella.Business.Concrete;
using Codebella.DataAccess.Abstract;
using Codebella.DataAccess.Concrete;
using Codebella.DataAccess.Context;
using Codebella.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Codebella.AutoMapperTier;

namespace Codebella.Infrastructure
{
    public static class ServiceExtension
    {

        public static IServiceCollection DependencyInjectionContainer(IServiceCollection services)
        {

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ILikeRepository, LikeRepository>();
            services.AddTransient<ITagRepository, TagRepository>();

            services.AddTransient<IArticleService, ArticleManager>();
            services.AddTransient<IAuthorService, AuthorManager>();
            services.AddTransient<ICategoryService, CategoryManager>();
            services.AddTransient<ICommentService, CommentManager>();
            services.AddTransient<ILikeService, LikeManager>();
            services.AddTransient<ITagService, TagManager>();

            services.AddAutoMapper(typeof(MapperProfile));

            return services;
        }

        public static IServiceCollection AddCodebellaInfraStructure(this IServiceCollection services, string connectionString) {

            services.AddDbContext<BlogContext>(options => {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Codebella.WebUI"));
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<BlogContext>();

            DependencyInjectionContainer(services);

            return services;
        }
    }
}