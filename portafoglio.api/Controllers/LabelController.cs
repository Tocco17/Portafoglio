using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class LabelController : LogicDeleteController<Label, LabelFilter>
{
	public LabelController(ILogger<Label> logger, IRepository<Label, LabelFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
