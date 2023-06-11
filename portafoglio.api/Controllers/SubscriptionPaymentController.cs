using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

public class SubscriptionPaymentController : LogicDeleteController<SubscriptionPayment, SubscriptionPaymentFilter>
{
	public SubscriptionPaymentController(ILogger<SubscriptionPayment> logger, IRepository<SubscriptionPayment, SubscriptionPaymentFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
