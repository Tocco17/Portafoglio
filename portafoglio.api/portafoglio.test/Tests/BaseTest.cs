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

namespace portafoglio.test.Tests;
public abstract class BaseTest
{
	protected PortafoglioDbContext _dbContext;

	protected EarningRepository _earningsRepos;
	protected EarningSuddivisionRepository _earningSuddivisionsRepos;
	protected LabelRepository _labelsRepos;
	protected TransactionRepository _transactionsRepos;
	protected UserRepository _usersRepos;
	protected WalletRepository _walletsRepos;

	[SetUp]
	public virtual void Setup()
	{
		InitializeDbContext();

		_earningsRepos = new EarningRepository(_dbContext);
		_earningSuddivisionsRepos = new EarningSuddivisionRepository(_dbContext);
		_labelsRepos = new LabelRepository(_dbContext);
		_transactionsRepos = new TransactionRepository(_dbContext);
		_usersRepos = new UserRepository(_dbContext);
		_walletsRepos = new WalletRepository(_dbContext);
	}

	[TearDown]
	public virtual void TearDown()
	{
		_dbContext.Dispose();
	}

	private void InitializeDbContext()
	{
		var serviceProvider = new ServiceCollection()
			.AddDbContext<PortafoglioDbContext>(options =>
				options.UseInMemoryDatabase(databaseName: "TestDatabase"))
			.BuildServiceProvider();

		_dbContext = serviceProvider.GetRequiredService<PortafoglioDbContext>();
		_dbContext.Database.EnsureCreated();
	}

}
