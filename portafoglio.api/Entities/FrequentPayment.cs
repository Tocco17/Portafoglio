namespace portafoglio.api.Entities;

public class FrequentPayment : IEntity
{
	public int Id { get; set; }

	public int IdUser { get; set; }
	public User? User { get; set; }

	public int IdLabel { get; set; }
	public Label? Label { get; set; } = null;

	public string Description { get; set; } = null!;

	public int Value { get; set; }
}
