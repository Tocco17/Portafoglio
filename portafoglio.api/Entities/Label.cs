using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[Index(nameof(IdUser), nameof(Name), IsUnique = true)]
public class Label : BaseLogicDeleteEntity
{
	public int IdUser { get; set; }
	[ForeignKey(nameof(IdUser))] public User? User { get; set; }

	public int? IdFatherLabel { get; set; } = null;
	[ForeignKey(nameof(IdFatherLabel))] public Label? FatherLabel { get; set; } = null;

	public string Name { get; set; } = null!;
	public string? Description { get; set; } = null;
}
