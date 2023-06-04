using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CreditController : LogicDeleteController<Credit, CreditFilter>
{
	public CreditController(ILogger<Credit> logger, IRepository<Credit, CreditFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
