using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class TransferController : LogicDeleteController<Transfer, TransferFilter>
{
	public TransferController(ILogger<Transfer> logger, IRepository<Transfer, TransferFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
