using Core.Entity.Concrete;

namespace Entity;

public class Comment : BaseEntity<User>
{
    public string Content { get; set; }
    public Article Article { get; set; }
    public User Owner { get; set; }
}

// Owner is actually same with CreatedBy property of BaseEntity. But an admin might want to create a comment for another user.