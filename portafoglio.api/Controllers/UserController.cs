using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class UserController : LogicDeleteController<User, UserFilter>
{
	public UserController(ILogger<User> logger, IRepository<User, UserFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
