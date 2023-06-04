using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class SubscriptionPaymentRepository : BaseRepository<SubscriptionPayment, SubscriptionPaymentFilter>
{
	public SubscriptionPaymentRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
