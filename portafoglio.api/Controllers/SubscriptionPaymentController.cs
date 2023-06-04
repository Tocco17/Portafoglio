using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class SubscriptionPaymentController : LogicDeleteController<SubscriptionPayment, SubscriptionPaymentFilter>
{
	public SubscriptionPaymentController(ILogger<SubscriptionPayment> logger, IRepository<SubscriptionPayment, SubscriptionPaymentFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
