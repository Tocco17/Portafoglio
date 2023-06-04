using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class SubscriptionPaymentFilter : IFilter<SubscriptionPayment>
{
	public IQueryable<SubscriptionPayment> GetFilteredQuery(IQueryable<SubscriptionPayment> baseQuery)
	{
		return baseQuery;
	}
}
