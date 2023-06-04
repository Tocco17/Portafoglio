using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class TransferFilter : IFilter<Transfer>
{
	public IQueryable<Transfer> GetFilteredQuery(IQueryable<Transfer> baseQuery)
	{
		return baseQuery;
	}
}
