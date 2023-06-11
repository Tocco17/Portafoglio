using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

public class UserController : LogicDeleteController<User, UserFilter>
{
	public UserController(ILogger<User> logger, IRepository<User, UserFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
