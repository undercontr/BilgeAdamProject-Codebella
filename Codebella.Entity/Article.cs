using Codebella.Core.Entity.Concrete;

namespace Codebella.Entity;

public class Article : BaseEntity
{
    public string Title { get; set; }
    public string? CoverImage { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public string Slug { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
    public virtual List<Tag> Tags { get; set; }
}