using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class SubscriptionRepository : BaseRepository<Subscription, SubscriptionFilter>
{
	public SubscriptionRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
