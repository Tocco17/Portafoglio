using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

public class DebtPaymentController : LogicDeleteController<DebtPayment, DebtPaymentFilter>
{
	public DebtPaymentController(ILogger<DebtPayment> logger, IRepository<DebtPayment, DebtPaymentFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
