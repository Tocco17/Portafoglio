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

	[HttpPost("login")]
	public async Task<ActionResult<User>> Login([FromBody] UserFilter filter)
	{
		var userFromDb = await _dbRepo.GetSingleByFilterAsync(filter);

		if (userFromDb == null)
			return NotFound("Incorrect username or password.");

		return Ok(userFromDb);
	}
}
