using Codebella.Core.Entity.Concrete;

namespace Codebella.Entity;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public IEnumerable<Article> Articles { get; set; }
}