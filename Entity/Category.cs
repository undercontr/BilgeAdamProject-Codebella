using Core.Entity.Concrete;

namespace Entity;

public class Category : BaseEntity<User>
{
    public string Name { get; set; }
    public string Slug { get; set; }
}