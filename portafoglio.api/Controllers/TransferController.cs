using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

public class TransferController : LogicDeleteController<Transfer, TransferFilter>
{
	public TransferController(ILogger<Transfer> logger, IRepository<Transfer, TransferFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
