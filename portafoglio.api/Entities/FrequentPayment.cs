using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(IdUser), IsUnique = false)]
public class FrequentPayment : BaseLogicDelete
{
	public int Id { get; set; }

	public int IdUser { get; set; }
	[ForeignKey(nameof(IdUser))] public User? User { get; set; }

	public int IdLabel { get; set; }
	[ForeignKey(nameof(IdLabel))] public Label? Label { get; set; } = null;

	public string Description { get; set; } = null!;

	public int Value { get; set; }
	public bool Active {get; set; }
}
