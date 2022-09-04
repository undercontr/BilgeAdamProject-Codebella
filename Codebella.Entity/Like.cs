using Codebella.Core.Entity.Concrete;

namespace Codebella.Entity;

public class Like : BaseEntity
{
    public User Owner { get; set; }
    public Article Article { get; set; }
}