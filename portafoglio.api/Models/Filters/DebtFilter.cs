using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class DebtFilter : IFilter<Debt>
{
	public IQueryable<Debt> GetFilteredQuery(IQueryable<Debt> baseQuery)
	{
		return baseQuery;
	}
}
