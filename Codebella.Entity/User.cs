using Codebella.Core.Entity.Abstract;
using Codebella.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Codebella.Entity;

public class User : IdentityUser, IEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public Status Status { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
}