using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class DebtPaymentFilter : IFilter<DebtPayment>
{
	public IQueryable<DebtPayment> GetFilteredQuery(IQueryable<DebtPayment> baseQuery)
	{
		return baseQuery;
	}
}
