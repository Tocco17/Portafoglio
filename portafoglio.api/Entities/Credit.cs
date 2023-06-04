using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(IdUser), IsUnique = false)]
public class Credit : ILogicDelete
{
	public int Id { get; set; }

	public int IdUser { get; set; }
	[ForeignKey(nameof(IdUser))] public User? User { get; set; } = null;

	public int TotalMoney { get; set; }
	public string Description { get; set; } = null!;

	public int HowManyInvolved { get; set; }
	public bool Active {get; set; }
}
