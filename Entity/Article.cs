using Core.Entity.Concrete;

namespace Entity;

public class Article : BaseEntity<User>
{
    public string Name { get; set; }
    public string CoverImage { get; set; }
    public string Content { get; set; }
    public Author Author { get; set; }
}