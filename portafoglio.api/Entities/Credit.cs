using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[Index(nameof(IdUser), IsUnique = false)]
public class Credit : BaseLogicDelete
{
	public int IdUser { get; set; }
	[ForeignKey(nameof(IdUser))] public User? User { get; set; } = null;

	public int TotalMoney { get; set; }
	public string Description { get; set; } = null!;

	public int HowManyInvolved { get; set; }
}
