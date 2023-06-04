using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[Index(nameof(IdUser), IsUnique = false)]
public class Debt : BaseLogicDelete
{
	public int IdUser { get; set; }
	[ForeignKey(nameof(IdUser))] public User? User { get; set; }

	public int Value { get; set; }

	public string Description { get; set; } = null!;
}