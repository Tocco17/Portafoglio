namespace portafoglio.api.Entities;

public class DebtPayment : IEntity
{
	public int Id {get; set;}

	public int IdTransaction { get; set; }
	public Transaction? Transaction { get; set; } = null;

	public int IdDebt { get; set; }
	public Debt? Debt { get; set; } = null;
}
