using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class FrequentPaymentPaymentFilter : IFilter<FrequentPaymentPayment>
{
	public IQueryable<FrequentPaymentPayment> GetFilteredQuery(IQueryable<FrequentPaymentPayment> baseQuery)
	{
		return baseQuery;
	}
}
