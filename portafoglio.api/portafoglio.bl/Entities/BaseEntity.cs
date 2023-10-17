using Microsoft.EntityFrameworkCore;

namespace portafoglio.bl.Entities;

[PrimaryKey(nameof(Id))]
public abstract class BaseEntity
{
    public Guid Id { get; set; }
}

public abstract class LogicDeleteEntity : BaseEntity
{
    public bool IsActive { get; set; } = true;
}
