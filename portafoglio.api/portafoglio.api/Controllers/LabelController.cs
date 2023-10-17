using Microsoft.AspNetCore.Mvc;
using portafoglio.bl.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LabelController : BaseLogicDeleteController<Label, LabelFilter>
{
	public LabelController(IRepository<Label, LabelFilter> dbRepo, ILogicDeleteRepository<Label, LabelFilter> dbLogicDeleteRepo) : base(dbRepo, dbLogicDeleteRepo)
	{
	}
}
