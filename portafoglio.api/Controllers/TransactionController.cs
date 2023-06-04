using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class TransactionController : LogicDeleteController<Transaction, TransactionFilter>
{
	public TransactionController(ILogger<Transaction> logger, IRepository<Transaction, TransactionFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
