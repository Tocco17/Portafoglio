namespace portafoglio.api.Entities;

public class Label : IEntity, ILogicDelete
{
	public int Id {get; set;}
	public bool Active { get; set; }

	/// <summary>
	/// User id this label belongs to
	/// </summary>
	public int IdUser { get; set; }

	/// <summary>
	/// User this label belongs to
	/// </summary>
	public User? User { get; set; }

	/// <summary>
	/// Id of the its father label
	/// </summary>
	public int? IdFatherLabel { get; set; } = null;

	/// <summary>
	/// Its father label
	/// </summary>
	public Label? FatherLabel { get; set; } = null;

	public string Name { get; set; } = null!;
	public string? Description { get; set; } = null;
}
