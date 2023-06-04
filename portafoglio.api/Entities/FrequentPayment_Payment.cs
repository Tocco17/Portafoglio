using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(IdTransaction), nameof(IdFrequentPayment), IsUnique = true)]
public class FrequentPayment_Payment : BaseLogicDelete
{
	public int Id {get; set;}

	public int IdTransaction { get; set; }
	[ForeignKey(nameof(IdTransaction))] public Transaction? Transaction { get; set; }

	public int IdFrequentPayment { get; set; }
	[ForeignKey(nameof(IdFrequentPayment))] public FrequentPayment? FrequentPayment { get; set; } = null;

	public bool Active {get; set;}
}
