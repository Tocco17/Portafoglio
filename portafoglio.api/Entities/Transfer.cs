using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace portafoglio.api.Entities;

[Index(nameof(IdPortafoglioFrom), nameof(IdPortafoglioTo), IsUnique = false)]
public class Transfer : BaseLogicDelete
{
	public int IdPortafoglioFrom { get; set; }
	[ForeignKey(nameof(IdPortafoglioFrom))] public Portafoglio? From { get; set; } = null;

	public int IdPortafoglioTo { get; set; }
	[ForeignKey(nameof(IdPortafoglioTo))] public Portafoglio? To { get; set; } = null;

	public int Value { get; set; }

	public DateTime Date { get; set; }
}
