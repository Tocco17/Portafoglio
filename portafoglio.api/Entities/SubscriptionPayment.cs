using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(IdTransaction), nameof(IdSubscription), IsUnique = true)]
public class SubscriptionPayment : ILogicDelete
{
	public int Id {get; set;}

	public int IdTransaction { get; set; }
	[ForeignKey(nameof(IdTransaction))] public Transaction? Transaction { get; set; } = null;

	public int IdSubscription { get; set; }
	[ForeignKey(nameof(IdSubscription))] public Subscription? Subscription { get; set; } = null;

	public DateTime Date { get; set; }
	public bool Active {get; set; }
}
