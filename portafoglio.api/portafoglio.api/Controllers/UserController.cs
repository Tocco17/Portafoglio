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

	[HttpGet("Login")]
	public async Task<ActionResult<Guid>> Login([FromBody] User user)
	{
		var filter = new UserFilter
		{
			Username = user.Username,
			Password = user.Password,
		};

		var userFromDb = await _dbRepo.GetSingleOrDefaultAsync(filter);
		var guid = userFromDb?.Id ?? null;

		if(guid == null)
			return BadRequest();

		return Ok(guid);
	}
}
