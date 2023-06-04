using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(IdTransaction), nameof(IdDebt), IsUnique = true)]
public class DebtPayment : ILogicDelete
{
	public int Id {get; set;}

	public int IdTransaction { get; set; }
	[ForeignKey(nameof(IdTransaction))] public Transaction? Transaction { get; set; } = null;

	public int IdDebt { get; set; }
	[ForeignKey(nameof(IdDebt))] public Debt? Debt { get; set; } = null;

	public bool Active {get; set;}
}
