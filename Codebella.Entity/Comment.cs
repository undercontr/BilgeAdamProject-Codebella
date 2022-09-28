using Codebella.Core.Entity.Concrete;

namespace Codebella.Entity;

public class Comment : BaseEntity
{

    public string Content { get; set; }
    public int ArticleId { get; set; }
    public virtual Article Article { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
}