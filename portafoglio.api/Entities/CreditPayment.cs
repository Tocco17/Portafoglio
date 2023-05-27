namespace portafoglio.api.Entities;

public class CreditPayment : IEntity
{
	public int Id {get;set;}

	public int IdTransaction { get; set; }
	public Transaction? Transaction { get; set; } = null;

	public int IdCredit { get; set; }
	public Credit? Credit { get; set; }
}
