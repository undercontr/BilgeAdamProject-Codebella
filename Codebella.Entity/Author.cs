using Codebella.Core.Entity.Concrete;

namespace Codebella.Entity;

public class Author: BaseEntity
{
    public string Nickname { get; set; }
    public string FullName { get; set; }
    public User UserInfo { get; set; }
    public IEnumerable<Article> Articles { get; set; }
}