using Microsoft.EntityFrameworkCore;

namespace portafoglio.api.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(Username), IsUnique = true)]
public class User : BaseLogicDeleteEntity
{
	public string Username { get; set; } = null!;

	public string Password { get; set; } = null!;
}
