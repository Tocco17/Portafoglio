using Microsoft.EntityFrameworkCore;

namespace portafoglio.api.Entities;

[PrimaryKey(nameof(Id))]
public class BaseEntity
{
	/// <summary>
	/// Id of this entity
	/// </summary>
	public int Id { get; set; }
}
