using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class FrequentPaymentPaymentController : LogicDeleteController<FrequentPaymentPayment, FrequentPaymentPaymentFilter>
{
	public FrequentPaymentPaymentController(ILogger<FrequentPaymentPayment> logger, IRepository<FrequentPaymentPayment, FrequentPaymentPaymentFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
