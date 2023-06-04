using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class PortafoglioFilter : IFilter<Portafoglio>
{
	public IQueryable<Portafoglio> GetFilteredQuery(IQueryable<Portafoglio> baseQuery)
	{
		return baseQuery;
	}
}
