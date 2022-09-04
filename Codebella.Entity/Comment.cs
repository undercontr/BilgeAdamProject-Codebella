using Codebella.Core.Entity.Concrete;

namespace Codebella.Entity;

public class Comment : BaseEntity
{
    public string Content { get; set; }
    public Guid ArticleId { get; set; }
    public Article Article { get; set; }
    public Guid OwnerId { get; set; }
    public User Owner { get; set; }
}

// Owner is actually same with CreatedBy property of BaseEntity. But an admin might want to create a comment for another user.