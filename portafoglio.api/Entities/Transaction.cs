namespace portafoglio.api.Entities;

public class Transaction : IEntity
{
	public int Id {get; set;}

	public int IdPortafoglio { get; set; }
	public Portafoglio? Portafoglio { get; set; } = null;

	public int IdLabel { get; set; }
	public Label? Label { get; set; } = null;

	public string Description { get; set; } = null!;

	public int Value { get; set; }

	public DateTime Date { get; set; }
}
