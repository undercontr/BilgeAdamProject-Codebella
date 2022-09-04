using Codebella.Core.Entity.Abstract;
using Codebella.Core.Enums;

namespace Codebella.Core.Entity.Concrete;

/// <summary>
/// An base entity abstraction that each entity should extend from.
/// </summary>
/// <typeparam name="TUser">The user type that will hold created and updated user of a single record</typeparam>
public abstract class BaseEntity : IEntity, IBaseEntity<Guid>
{

    public Guid Id { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public Status Status { get; set; }
}