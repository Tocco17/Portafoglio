using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[Index(nameof(IdTransaction), nameof(IdFrequentPayment), IsUnique = true)]
public class FrequentPaymentPayment : BaseLogicDeleteEntity
{
	public int IdTransaction { get; set; }
	[ForeignKey(nameof(IdTransaction))] public Transaction? Transaction { get; set; }

	public int IdFrequentPayment { get; set; }
	[ForeignKey(nameof(IdFrequentPayment))] public FrequentPayment? FrequentPayment { get; set; } = null;
}
