using Codebella.Core.Entity.Concrete;

namespace Codebella.Entity;

public class Article : BaseEntity
{
    public string Name { get; set; }
    public string CoverImage { get; set; }
    public string Content { get; set; }
    public int ViewCount { get; set; }
    public Author Author { get; set; }
    public IEnumerable<Comment>? Comments { get; set; }
    public IEnumerable<Like> Likes { get; set; }
    public IEnumerable<Tag> Tags { get; set; }
}