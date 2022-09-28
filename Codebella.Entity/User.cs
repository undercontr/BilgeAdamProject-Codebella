using Codebella.Core.Entity.Abstract;
using Codebella.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Codebella.Entity;

public class User : IdentityUser<int>, IEntity
{

    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public Status Status { get; set; }
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public virtual IEnumerable<Comment> Comments {get;set;}
}