using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Models.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : BaseLogicDeleteController<User, UserFilter>
{
	public UserController(IRepository<User, UserFilter> dbRepo, ILogicDeleteRepository<User, UserFilter> dbLogicDeleteRepo) : base(dbRepo, dbLogicDeleteRepo)
	{
	}
}
