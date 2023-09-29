using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Models.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EarningSuddivisionController : BaseLogicDeleteController<EarningSuddivision, EarningSuddivisionFilter>
{
	public EarningSuddivisionController(IRepository<EarningSuddivision, EarningSuddivisionFilter> dbRepo, ILogicDeleteRepository<EarningSuddivision, EarningSuddivisionFilter> dbLogicDeleteRepo) : base(dbRepo, dbLogicDeleteRepo)
	{
	}
}
