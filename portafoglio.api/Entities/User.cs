namespace portafoglio.api.Entities;

public class User : IEntity, ILogicDelete
{
	public int Id { get; set; }

	/// <summary>
	/// Username of the user
	/// </summary>
	public string Username { get; set; } = null!;

	/// <summary>
	/// Password of the user
	/// </summary>
	public string Password { get; set; } = null!;

	public bool Active {get; set;}
}
