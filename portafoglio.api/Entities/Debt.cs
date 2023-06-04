using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(IdUser), IsUnique = false)]
public class Debt : BaseLogicDelete
{
	public int Id {get; set;}

	public int IdUser { get; set; }
	[ForeignKey(nameof(IdUser))] public User? User { get; set; }

	public int Value { get; set; }

	public string Description { get; set; } = null!;
	public bool Active {get; set; }
}