namespace portafoglio.api.Entities;

public class Debt : IEntity
{
	public int Id {get; set;}

	public int IdUser { get; set; }
	public User? User { get; set; }

	public int Value { get; set; }

	public string Description { get; set; } = null!;
}