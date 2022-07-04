using Core.Entity.Concrete;

namespace Entity;

public class Author: BaseEntity<User>
{
    public ICollection<Article> Articles { get; set; }
    public string Nickname { get; set; }
    public string FullName { get; set; }
    public User UserInfo { get; set; }
}