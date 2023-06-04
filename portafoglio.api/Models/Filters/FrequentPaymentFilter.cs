using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class FrequentPaymentFilter : IFilter<FrequentPayment>
{
	public IQueryable<FrequentPayment> GetFilteredQuery(IQueryable<FrequentPayment> baseQuery)
	{
		return baseQuery;
	}
}
