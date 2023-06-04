using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class CreditFilter : IFilter<Credit>
{
	public IQueryable<Credit> GetFilteredQuery(IQueryable<Credit> baseQuery)
	{
		return baseQuery;
	}
}
