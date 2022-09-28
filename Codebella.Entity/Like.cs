using Codebella.Core.Entity.Concrete;

namespace Codebella.Entity;

public class Like : BaseEntity
{
    public int OwnerId { get; set; }
    public virtual User Owner { get; set; }
    public int ArticleId { get; set; }
    public virtual Article Article { get; set; }
}