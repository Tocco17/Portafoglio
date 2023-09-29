using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace portafoglio.api.Models.Entities;

[Index(nameof(Username), IsUnique = true)]
public class User : LogicDeleteEntity
{
	[Required] public string Username { get; set; } = null!;
	[Required] public string Password { get; set; } = null!;

	[InverseProperty("User")]
	public ICollection<Earning>? Earnings { get; set; }

	[InverseProperty("User")]
	public ICollection<EarningSuddivision>? EarningSuddivisions { get; set; }

	[InverseProperty("User")]
	public ICollection<Wallet>? Wallets { get; set; }
}
