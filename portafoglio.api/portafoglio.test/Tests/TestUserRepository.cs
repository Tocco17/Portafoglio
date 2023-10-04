using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using portafoglio.api.Contextes;
using portafoglio.api.Models.Entities;
using portafoglio.api.Repositories;
using portafoglio.test.Repository;

namespace portafoglio.test.Tests;
public class TestUserRepository
{
	private PortafoglioDbContext _dbContext;
	private UserRepository _userRepo;

	[SetUp]
	public async Task Setup()
	{
		var serviceProvider = new ServiceCollection()
			.AddDbContext<PortafoglioDbContext>(options =>
				options.UseInMemoryDatabase(databaseName: "TestDatabase"))
			.BuildServiceProvider();

		_dbContext = serviceProvider.GetRequiredService<PortafoglioDbContext>();
		_dbContext.Database.EnsureCreated(); // Crea il database in memoria

		//Ora puoi istanziare il repository con il DbContext simulato
	   _userRepo = new UserRepository(_dbContext);

		var idList = new List<Guid>
		{
			new Guid("a1276c4c-e5c9-4045-80fe-9abeab960a0b"),
			new Guid("3e248cbe-7398-4e9e-817d-32b00bc18f14"),
			new Guid("c4c72840-070c-491f-92c9-802dc1fe3fdc"),
			new Guid("e5f6ec10-9b1f-4845-8506-c3b3036edf06"),
			new Guid("78b2c626-ce88-4e4f-8edc-6613c0d11f0a"),
			new Guid("8f96e191-2040-428c-8d65-3bf8810b0dda"),
			new Guid("90327260-1927-4ebf-9e2a-47939829dc37"),
			new Guid("7b5eca83-fa98-4ade-9b56-59a8861330fc"),
			new Guid("007223b7-13e9-4177-95d6-553c609c1e0e"),
			new Guid("7965f435-6ea2-4b43-b4d8-811618807b72"),
		};

		var userList = idList.Select(x => new User
		{
			Id = x,
			Username = $"TestUser{x}",
			Password = $"TestPsw{x}"
		});

		await _userRepo.AddAsync(userList);
	}

	[Test]
	public async Task Add()
	{
		var user = new User
		{
			Username = "Test",
			Password = "password",
		};

		var id = await _userRepo.AddAsync(user);

		var userFromDb = await _userRepo.GetByIdAsync(id);

		Assert.Multiple(() =>
		{
			Assert.That(id, Is.Not.EqualTo(Guid.Empty));
			Assert.That(userFromDb, Is.Not.Null);
		});

	}

	[Test]
	public async Task AddMultiple()
	{
		var idList = new List<Guid>
		{
			new Guid("a1276c4c-e5c9-4045-80fe-9abeab960a0b"),
			new Guid("3e248cbe-7398-4e9e-817d-32b00bc18f14"),
			new Guid("c4c72840-070c-491f-92c9-802dc1fe3fdc"),
			new Guid("e5f6ec10-9b1f-4845-8506-c3b3036edf06"),
			new Guid("78b2c626-ce88-4e4f-8edc-6613c0d11f0a"),
			new Guid("8f96e191-2040-428c-8d65-3bf8810b0dda"),
			new Guid("90327260-1927-4ebf-9e2a-47939829dc37"),
			new Guid("7b5eca83-fa98-4ade-9b56-59a8861330fc"),
			new Guid("007223b7-13e9-4177-95d6-553c609c1e0e"),
			new Guid("7965f435-6ea2-4b43-b4d8-811618807b72"),
		};

		var userList = idList.Select(x => new User
		{
			Id = x,
			Username = $"TestUser{x}",
			Password = $"TestPsw{x}"
		});

		var idsFromDb = await _userRepo.AddAsync(userList);

		Assert.That(idsFromDb.Count(), Is.EqualTo(idList.Count));

	}
}
