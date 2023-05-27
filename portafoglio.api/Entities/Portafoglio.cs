namespace portafoglio.api.Entities;

public class Portafoglio : IEntity, ILogicDelete
{
	public int Id {get; set;}
	public bool Active { get; set; }

	/// <summary>
	/// User id this wallet belong to
	/// </summary>
	public int IdUser { get; set; }

	/// <summary>
	/// User this wallet belongs to
	/// </summary>
	public User? User { get; set; }

	/// <summary>
	/// Name of the wallet
	/// </summary>
	public string Name { get; set; } = null!;

	/// <summary>
	/// Description of this wallet, like what it serves for
	/// </summary>
	public string? Description { get; set; } = null;

	/// <summary>
	/// How many moneys are in this wallet
	/// </summary>
	public int Moneys { get; set; }


	/// <summary>
	/// Last time it was updated
	/// </summary>
	public DateTime LastUpdate { get; set; }
}
