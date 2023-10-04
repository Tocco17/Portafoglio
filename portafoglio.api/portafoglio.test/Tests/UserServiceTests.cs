using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using portafoglio.api.Models.Entities;
using portafoglio.api.Repositories;
using portafoglio.api.Services;

namespace portafoglio.test.Tests;
public class UserServiceTests : BaseTest
{
	private UserService _userService;

	public override async Task Setup()
	{
		await base.Setup();
		_userService = new UserService(
			_earningsRepos,
			_earningSuddivisionsRepos,
			_labelsRepos,
			_usersRepos,
			_walletsRepos
			);
	}

	[Test]
	public async Task AddUser()
	{
		var id = Guid.NewGuid();
		var user = new User
		{
			Id = id,
			Username = "Test",
			Password = "Test",
		};

		var idCreated = await _userService.CreateUser( user );

		var userFromDb = await _usersRepos.GetByIdAsync( idCreated );

		Assert.IsNotNull( userFromDb );
	}
}
