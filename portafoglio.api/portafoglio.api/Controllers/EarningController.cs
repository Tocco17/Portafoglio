using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Models.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EarningController : BaseController<Earning, EarningFilter>
{
	public EarningController(IRepository<Earning, EarningFilter> dbRepo) : base(dbRepo)
	{
	}
}
