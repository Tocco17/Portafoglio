using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace portafoglio.api.Models.Entities;

[Index(nameof(IdWallet), IsUnique = false)]
[Index(nameof(IdLabel), IsUnique = false)]
[Index(nameof(Date), IsUnique = false)]
public class Transaction : BaseEntity
{
	[Required] public Guid IdLabel { get; set; }
	[Required] public Guid IdWallet { get; set; }
	[Required] public string Description { get; set; } = null!;
	[Required] public int Value { get; set; }
	[Required] public DateTime Date { get; set; } = DateTime.UtcNow;

	[ForeignKey(nameof(IdLabel))]
	public Label? Label { get; set; }

	[ForeignKey(nameof(IdWallet))]
	public Wallet? Wallet { get; set; }
}
