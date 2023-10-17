using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace portafoglio.bl.Entities;

[Index(nameof(IdUser), nameof(Name), IsUnique = true)]
public class Wallet : LogicDeleteEntity
{
    [Required] public Guid IdUser { get; set; }
    [Required] public string Name { get; set; } = null!;
    public string? Description { get; set; }

    [Required] public int Money { get; set; }
    [Required] public DateTime LastUpdate { get; set; }

    [ForeignKey(nameof(IdUser))]
    public User? User { get; set; }

    [InverseProperty("Wallet")]
    public ICollection<Transaction>? Transactions { get; set; }


}
