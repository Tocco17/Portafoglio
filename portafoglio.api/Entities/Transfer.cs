namespace portafoglio.api.Entities;

public class Transfer : IEntity
{
	public int Id {get; set;}

	public int IdPortafoglioFrom { get; set; }
	public Portafoglio? From { get; set; } = null;

	public int IdPortafoglioTo { get; set; }
	public Portafoglio? To { get; set; } = null;

	public int Value { get; set; }

	public DateTime Date { get; set; }
}
