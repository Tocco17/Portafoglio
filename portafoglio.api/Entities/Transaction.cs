using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(IdPortafoglio), IsUnique = false)]
[Index(nameof(IdLabel), IsUnique = false)]
public class Transaction : BaseLogicDelete
{
	public int Id {get; set;}

	public int IdPortafoglio { get; set; }
	public Portafoglio? Portafoglio { get; set; } = null;

	public int IdLabel { get; set; }
	[ForeignKey(nameof(IdLabel))] public Label? Label { get; set; } = null;

	public string Description { get; set; } = null!;

	public int Value { get; set; }

	public DateTime Date { get; set; }
	public bool Active {get; set; }
}
