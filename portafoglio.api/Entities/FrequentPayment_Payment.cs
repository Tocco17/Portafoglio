namespace portafoglio.api.Entities;

public class FrequentPayment_Payment : IEntity
{
	public int Id {get; set;}

	public int IdTransaction { get; set; }
	public Transaction? Transaction { get; set; }

	public int IdFrequentPayment { get; set; }
	public FrequentPayment? FrequentPayment { get; set; } = null;
}
