using Codebella.Core.Entity.Concrete;

namespace Codebella.Entity;

public class Author: BaseEntity
{
    public string Nickname { get; set; }
    public string? FullName { get; set; }

    public virtual User User { get; set; }
    public virtual IEnumerable<Article> Articles { get; set; }
}