using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[Index(nameof(IdUser), nameof(Name), IsUnique = true)]
public class Portafoglio : BaseLogicDeleteEntity
{
	public int IdUser { get; set; }
	[ForeignKey(nameof(IdUser))] public User? User { get; set; }

	public string Name { get; set; } = null!;

	public string? Description { get; set; } = null;

	public int Moneys { get; set; }

	public DateTime LastUpdate { get; set; }
}
