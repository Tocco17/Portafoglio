using Microsoft.EntityFrameworkCore;

namespace portafoglio.api.Entities;

public interface IEntity
{
	/// <summary>
	/// Id of this entity
	/// </summary>
	public int Id { get; set; }
}
