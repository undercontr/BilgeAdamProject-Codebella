using Core.Entity.Concrete;

namespace Entity;

public class Article : BaseEntity<User>
{
    public string Name { get; set; }
    public string CoverImage { get; set; }
    public string Content { get; set; }
    public int ViewCount { get; set; }
    public Author Author { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
    public ICollection<Tag> Tags { get; set; }
}