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
	public virtual async Task Setup()
	{
		InitializeDbContext();
		await InitializeEarningsRepos();
		await InitializeEarningSuddivisionsRepos();
		await InitializeLabelsRepos();
		await InitializeTransactionsRepos();
		await InitializeUsersRepos();
		await InitializeWalletsRepos();

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

	private async Task InitializeEarningsRepos()
	{
		_earningsRepos = new EarningRepository(_dbContext);
	}

	private async Task InitializeEarningSuddivisionsRepos()
	{
		_earningSuddivisionsRepos = new EarningSuddivisionRepository(_dbContext);
	}

	private async Task InitializeLabelsRepos()
	{
		_labelsRepos = new LabelRepository(_dbContext);
	}

	private async Task InitializeTransactionsRepos()
	{
		_transactionsRepos = new TransactionRepository(_dbContext);
	}

	private async Task InitializeUsersRepos()
	{
		_usersRepos = new UserRepository(_dbContext);
	}

	private async Task InitializeWalletsRepos()
	{
		_walletsRepos = new WalletRepository(_dbContext);
	}
}
