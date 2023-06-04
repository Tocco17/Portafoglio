using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[Index(nameof(IdTransaction), nameof(IdDebt), IsUnique = true)]
public class DebtPayment : BaseLogicDeleteEntity
{
	public int IdTransaction { get; set; }
	[ForeignKey(nameof(IdTransaction))] public Transaction? Transaction { get; set; } = null;

	public int IdDebt { get; set; }
	[ForeignKey(nameof(IdDebt))] public Debt? Debt { get; set; } = null;
}
