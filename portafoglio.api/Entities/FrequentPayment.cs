using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[Index(nameof(IdUser), IsUnique = false)]
public class FrequentPayment : BaseLogicDeleteEntity
{
	public int IdUser { get; set; }
	[ForeignKey(nameof(IdUser))] public User? User { get; set; }

	public int IdLabel { get; set; }
	[ForeignKey(nameof(IdLabel))] public Label? Label { get; set; } = null;

	public string Description { get; set; } = null!;

	public int Value { get; set; }
}
