using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace portafoglio.api.Models.Entities;

[Index(nameof(IdUser), IsUnique = false)]
public class Earning : BaseEntity
{
	[Required] public Guid IdUser { get; set; }
	[Required] public int Value { get; set; }
	[Required] public DateTime Date { get; set; }


	[ForeignKey(nameof(IdUser))]
	public User? User { get; set; } = null;
}
