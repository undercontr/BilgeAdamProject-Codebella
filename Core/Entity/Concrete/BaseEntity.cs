using Core.Entity.Abstract;
using Core.Enums;

namespace Core.Entity.Concrete;

/// <summary>
/// An base entity abstraction that each entity should extend.
/// </summary>
/// <typeparam name="TUser">The user type that will hold created and updated user of a single record</typeparam>
public abstract class BaseEntity<TUser> : IEntity, IBaseEntity<Guid>
{

    public Guid Id { get; set; }
    public TUser CreatedBy { get; set; }
    public TUser UpdatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public Status Status { get; set; }
}