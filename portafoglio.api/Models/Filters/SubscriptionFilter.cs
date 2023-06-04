using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class SubscriptionFilter : IFilter<Subscription>
{
	public IQueryable<Subscription> GetFilteredQuery(IQueryable<Subscription> baseQuery)
	{
		return baseQuery;
	}
}
