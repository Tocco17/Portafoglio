using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

public class TransactionController : LogicDeleteController<Transaction, TransactionFilter>
{
	public TransactionController(ILogger<Transaction> logger, IRepository<Transaction, TransactionFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
