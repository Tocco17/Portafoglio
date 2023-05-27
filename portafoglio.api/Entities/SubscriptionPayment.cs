namespace portafoglio.api.Entities;

public class SubscriptionPayment : IEntity
{
	public int Id {get; set;}

	public int IdTransaction { get; set; }
	public Transaction? Transaction { get; set; } = null;

	public int IdSubscription { get; set; }
	public Subscription? Subscription { get; set; } = null;

	public DateTime Date { get; set; }
}
