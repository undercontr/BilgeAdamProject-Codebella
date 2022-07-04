using Core.Entity.Concrete;

namespace Entity;

public class Like : BaseEntity<User>
{
    public User Owner { get; set; }
    public Article Article { get; set; }
}