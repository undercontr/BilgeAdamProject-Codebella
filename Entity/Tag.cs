using Core.Entity.Concrete;

namespace Entity;

public class Tag : BaseEntity<User>
{
    public string Name { get; set; }
    public ICollection<Article> Articles { get; set; } 
}