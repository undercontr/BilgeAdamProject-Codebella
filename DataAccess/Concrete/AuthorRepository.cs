using Core.Entity.Abstract;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity;

namespace DataAccess.Concrete;

public class AuthorRepository : BaseRepository<Author, BlogContext>, IAuthorRepository
{
    protected AuthorRepository(BlogContext context) : base(context)
    {
    }
}