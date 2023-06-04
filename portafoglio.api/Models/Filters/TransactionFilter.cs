using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class TransactionFilter : IFilter<Transaction>
{
	public IQueryable<Transaction> GetFilteredQuery(IQueryable<Transaction> baseQuery)
	{
		return baseQuery;
	}
}
