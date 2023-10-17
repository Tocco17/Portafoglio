using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace portafoglio.bl.Entities;

[Index(nameof(IdEarningSuddivision), nameof(Name), IsUnique = true)]
public class Label : LogicDeleteEntity
{
    [Required] public Guid IdEarningSuddivision { get; set; }
    [Required] public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public Guid? IdFatherLabel { get; set; } = null;

    [ForeignKey(nameof(IdFatherLabel))]
    public Label? FatherLabel { get; set; }

    [ForeignKey(nameof(IdEarningSuddivision))]
    public EarningSuddivision? EarningSuddivision { get; set; }


    [InverseProperty(nameof(FatherLabel))]
    public ICollection<Label>? ChildrenLabels { get; set; }

    [InverseProperty("Label")]
    public ICollection<Transaction>? Transactions { get; set; }
}
