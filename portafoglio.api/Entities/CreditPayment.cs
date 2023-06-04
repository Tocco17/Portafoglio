using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(IdTransaction), nameof(IdCredit), IsUnique = true)]
public class CreditPayment : BaseLogicDelete
{
	public int Id {get;set;}

	public int IdTransaction { get; set; }
	[ForeignKey(nameof(IdTransaction))] public Transaction? Transaction { get; set; } = null;

	public int IdCredit { get; set; }
	[ForeignKey(nameof(IdCredit))] public Credit? Credit { get; set; }

	public bool Active {get; set; }
}
