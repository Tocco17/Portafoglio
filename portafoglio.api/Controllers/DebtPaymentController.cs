using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class DebtPaymentController : LogicDeleteController<DebtPayment, DebtPaymentFilter>
{
	public DebtPaymentController(ILogger<DebtPayment> logger, IRepository<DebtPayment, DebtPaymentFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
