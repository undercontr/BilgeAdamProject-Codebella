using Codebella.Core.Enums;

namespace Codebella.Core.Entity.Abstract;

public interface IEntity
{
    DateTime CreatedOn { get; set; }
    DateTime UpdatedOn { get; set; }
    Status Status { get; set; }
}