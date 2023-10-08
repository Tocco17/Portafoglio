using System.ComponentModel.DataAnnotations;
using portafoglio.api.Models.Entities;

namespace portafoglio.api.Models.Filters;

public class WalletFilter : BaseLogicDeleteFilter<Wallet>
{
	public Guid? IdUser { get; set; } = null;
	public string? Name { get; set; } = null;
	public string? Description { get; set; } = null;
	public int? Money { get; set; } = null;
	public DateTime? LastUpdate { get; set; } = null;

	public override IQueryable<Wallet> GetOptionsFilterQuery(IQueryable<Wallet> baseQuery)
	{
		var query = baseQuery.AsQueryable();

		if(IdUser != null) 
			query = query.Where(x => x.IdUser == IdUser);

		if(Name != null) 
			query = query.Where(x => x.Name.Contains(Name));

		if(Description != null) 
			query = query.Where(x => x.Description != null && x.Description.Contains(Description));

		if(Money != null) 
			query = query.Where(x => x.Money == Money);

		if (LastUpdate != null)
			query = query.Where(x => x.LastUpdate == LastUpdate);


		return base.GetOptionsFilterQuery(query);
	}
}
