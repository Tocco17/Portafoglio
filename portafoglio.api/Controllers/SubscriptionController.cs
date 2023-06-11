using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

public class SubscriptionController : LogicDeleteController<Subscription, SubscriptionFilter>
{
	public SubscriptionController(ILogger<Subscription> logger, IRepository<Subscription, SubscriptionFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
