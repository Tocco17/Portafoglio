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
	public async Task<ActionResult<User>> Login([FromBody] User user)
	{
		var userFromDb = await _dbRepo.GetSingleByFilterAsync(new UserFilter
		{
			Username = user.Username,
			Password = user.Password
		});

		if (userFromDb == null)
			return NotFound("Incorrect username or password.");

		return Ok(userFromDb);
	}
}
