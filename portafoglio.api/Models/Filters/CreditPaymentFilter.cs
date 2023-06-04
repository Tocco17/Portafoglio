using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class CreditPaymentFilter : IFilter<CreditPayment>
{
	public IQueryable<CreditPayment> GetFilteredQuery(IQueryable<CreditPayment> baseQuery)
	{
		return baseQuery;
	}
}
