using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[Index(nameof(IdTransaction), nameof(IdCredit), IsUnique = true)]
public class CreditPayment : BaseLogicDeleteEntity
{
	public int IdTransaction { get; set; }
	[ForeignKey(nameof(IdTransaction))] public Transaction? Transaction { get; set; } = null;

	public int IdCredit { get; set; }
	[ForeignKey(nameof(IdCredit))] public Credit? Credit { get; set; }
}
