using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[Index(nameof(IdTransaction), nameof(IdSubscription), IsUnique = true)]
public class SubscriptionPayment : BaseLogicDeleteEntity
{
	public int IdTransaction { get; set; }
	[ForeignKey(nameof(IdTransaction))] public Transaction? Transaction { get; set; } = null;

	public int IdSubscription { get; set; }
	[ForeignKey(nameof(IdSubscription))] public Subscription? Subscription { get; set; } = null;

	public DateTime Date { get; set; }
}
