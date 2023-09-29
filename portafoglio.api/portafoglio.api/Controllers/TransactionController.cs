using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Models.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : BaseController<Transaction, TransactionFilter>
{
	public TransactionController(IRepository<Transaction, TransactionFilter> dbRepo) : base(dbRepo)
	{
	}
}
