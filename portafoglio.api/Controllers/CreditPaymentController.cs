using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

public class CreditPaymentController : LogicDeleteController<CreditPayment, CreditPaymentFilter>
{
	public CreditPaymentController(ILogger<CreditPayment> logger, IRepository<CreditPayment, CreditPaymentFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
