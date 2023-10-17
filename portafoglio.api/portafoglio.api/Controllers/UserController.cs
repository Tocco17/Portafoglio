using Microsoft.AspNetCore.Mvc;
using portafoglio.bl.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;
using portafoglio.api.Services;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : BaseLogicDeleteController<User, UserFilter>
{
	private readonly UserService _userService;

	public UserController(IRepository<User, UserFilter> dbRepo, ILogicDeleteRepository<User, UserFilter> dbLogicDeleteRepo, UserService userService) : base(dbRepo, dbLogicDeleteRepo)
	{
		_userService = userService;
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

	public async override Task<ActionResult<Guid>> Post([FromBody] User entity)
	{
		var guid = await _userService.CreateUser(entity);
		return Ok(guid);
	}
}
