namespace portafoglio.api.Entities;

public interface ILogicDelete: IEntity
{
	/// <summary>
	/// Check if it's active or not
	/// </summary>
	public bool Active { get; set; }
}
