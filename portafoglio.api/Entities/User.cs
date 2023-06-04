using Microsoft.EntityFrameworkCore;

namespace portafoglio.api.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(Username), IsUnique = true)]
public class User : IEntity, ILogicDelete
{
	public int Id { get; set; }

	public string Username { get; set; } = null!;

	public string Password { get; set; } = null!;

	public bool Active {get; set;}
}
