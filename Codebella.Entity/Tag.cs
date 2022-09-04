using Codebella.Core.Entity.Concrete;

namespace Codebella.Entity;

public class Tag : BaseEntity
{
    public string Name { get; set; }
    public IEnumerable<Article> Articles { get; set; }
}