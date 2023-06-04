using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class PortafoglioController : LogicDeleteController<Portafoglio, PortafoglioFilter>
{
	public PortafoglioController(ILogger<Portafoglio> logger, IRepository<Portafoglio, PortafoglioFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
