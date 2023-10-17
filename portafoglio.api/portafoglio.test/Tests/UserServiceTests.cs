//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using portafoglio.bl.Entities;
//using portafoglio.api.Models.Filters;
//using portafoglio.api.Repositories;
//using portafoglio.api.Services;

//namespace portafoglio.test.Tests;
//public class UserServiceTests : BaseTest
//{
//	private UserService _userService;

//	public override void Setup()
//	{
//		base.Setup();

//		_userService = new UserService(
//			_earningsRepos,
//			_earningSuddivisionsRepos,
//			_labelsRepos,
//			_usersRepos,
//			_walletsRepos
//		);
//	}

//	[Test]
//	public async Task AddUser_UserCreated()
//	{
//		var id = Guid.NewGuid();
//		var user = new User
//		{
//			Id = id,
//			Username = "Test",
//			Password = "Test",
//		};

//		var idCreated = await _userService.CreateUser(user);

//		var userFromDb = await _usersRepos.GetByIdAsync(idCreated);

//		var isEqual = id == userFromDb.Id;

//		Assert.That(isEqual, Is.True);
//	}

//	[Test]
//	public async Task AddUser_WalletCreated()
//	{
//		var idUser = await CreateUser();

//		var filter = new WalletFilter
//		{
//			IdUser = idUser,
//		};

//		var wallet = await _walletsRepos.GetSingleOrDefaultAsync(filter);

//		Assert.IsNotNull(wallet);
//	}

//	[Test]
//	public async Task AddUser_EarningSuddivisionsCreated()
//	{
//		var idUser = await CreateUser();

//		var filter = new EarningSuddivisionFilter
//		{
//			IdUser = idUser,
//		};

//		var earningSuddivisions = await _earningSuddivisionsRepos.GetAsync(filter);

//		Assert.That(earningSuddivisions.Count, Is.EqualTo(3));
//	}

//	[Test]
//	public async Task AddUser_LabelsCreated()
//	{
//		var idUser = await CreateUser();

//		var filter = new LabelFilter
//		{
//			IdUser = idUser,
//		};

//		var labels = await _labelsRepos.GetAsync(filter);

//		Assert.That(labels.Count, Is.EqualTo(3));
//	}

//	private async Task<Guid> CreateUser()
//	{
//		var id = Guid.NewGuid();
//		var user = new User
//		{
//			Id = id,
//			Username = "Test",
//			Password = "Test",
//		};

//		var idCreated = await _userService.CreateUser(user);
//		return idCreated;
//	}
//}
