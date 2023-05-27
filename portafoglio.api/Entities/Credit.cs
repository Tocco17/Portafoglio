namespace portafoglio.api.Entities;

public class Credit : IEntity
{
	public int Id { get; set; }

	public int IdUser { get; set; }
	public User? User { get; set; } = null;

	public int TotalMoney { get; set; }
	public string Description { get; set; } = null!;

	public int HowManyInvolved { get; set; }
}
