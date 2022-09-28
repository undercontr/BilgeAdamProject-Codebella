using System.Diagnostics;
using Codebella.Core.Entity.Concrete;
using Codebella.Entity;
using Microsoft.EntityFrameworkCore;
using Codebella.DataAccess.Abstract;
using Codebella.DataAccess.Context;

namespace Codebella.DataAccess.Concrete;

public class AuthorRepository : BaseRepository<Author, BlogContext>, IAuthorRepository
{
    public AuthorRepository(BlogContext context) : base(context)
    {
    }
}