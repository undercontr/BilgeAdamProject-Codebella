using Codebella.Core.Entity.Concrete;

namespace Codebella.Entity;

public class Tag : BaseEntity
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public virtual IEnumerable<Article> Articles { get; set; }
}