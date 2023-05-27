namespace portafoglio.api.Entities;

public class Subscription : IEntity, ILogicDelete
{
	public int Id {get; set;}
	public bool Active { get; set; }

	public int IdUser { get; set; }
	public User? User { get; set; } = null;

	public int IdPortafoglio { get; set; }
	public Portafoglio? Portafoglio { get; set; } = null;

	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;

	public int Value { get; set; }

	public PeriodicityPayment Periodicity { get; set; }
}

public enum PeriodicityPayment
{
	Daily,
	Weekly,
	Monthly,
	Quarterly,
	SemiAnnual,
	Annual,
	Biennal,
}
