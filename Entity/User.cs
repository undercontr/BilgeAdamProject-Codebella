using Core.Entity.Abstract;
using Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Entity;

public class User : IdentityUser, IEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public Status Status { get; set; }
    public User CreatedBy { get; set; }
    public User UpdatedBy { get; set; }
}