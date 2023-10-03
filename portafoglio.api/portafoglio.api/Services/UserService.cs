using portafoglio.api.Models.Entities;
using portafoglio.api.Repositories;

namespace portafoglio.api.Services;

public class UserService
{
	private readonly EarningRepository _earningRepos;
	private readonly EarningSuddivisionRepository _earningSuddivisionRepos;
	private readonly LabelRepository _labelRepos;
	private readonly UserRepository _userRepos;
	private readonly WalletRepository _walletRepos;

	public UserService(EarningRepository earningRepos, EarningSuddivisionRepository earningSuddivisionRepos, LabelRepository labelRepos, UserRepository userRepos, WalletRepository walletRepos)
	{
		_earningRepos = earningRepos;
		_earningSuddivisionRepos = earningSuddivisionRepos;
		_labelRepos = labelRepos;
		_userRepos = userRepos;
		_walletRepos = walletRepos;
	}

	public async Task<Guid> CreateUser(User user)
	{
		await _userRepos.AddAsync(user);
		var wallet = await CreateWallet(user);
		var earningSuddivision = await CreateEarningSuddivions(user);
		var labels = CreateLabels(earningSuddivision);

		return user.Id;
	}

	private async Task<IEnumerable<EarningSuddivision>> CreateEarningSuddivions(User user)
	{
		var earningSuddivisions = new List<EarningSuddivision>
		{
			new EarningSuddivision
			{
				IdUser = user.Id,
				User = user,
				IsActive = true,
				Name = "Necessities",
				Description = "Needed expenses",
				Percentage = 50,
			},
			new EarningSuddivision
			{
				IdUser = user.Id,
				User = user,
				IsActive = true,
				Name = "Fun",
				Description = "Fun expenses",
				Percentage = 30,
			},
			new EarningSuddivision
			{
				IdUser = user.Id,
				User = user,
				IsActive = true,
				Name = "Savings",
				Description = "Saved moneys",
				Percentage = 20,
			},
		};

		await _earningSuddivisionRepos.AddAsync(earningSuddivisions);

		return earningSuddivisions;
	}

	private async Task<IEnumerable<Label>> CreateLabels(IEnumerable<EarningSuddivision> earningSuddivisions)
	{
		var labels = earningSuddivisions.Select(x => new Label
		{
			IdEarningSuddivision = x.Id,
			Name = x.Name,
			Description = x.Description,
			IdFatherLabel = null,
			IsActive = true,
		});

		await _labelRepos.AddAsync(labels);

		return labels;
	}

	private async Task<Wallet> CreateWallet(User user)
	{
		var wallet = new Wallet
		{
			IdUser = user.Id,
			User = user,
			IsActive = true,
			LastUpdate = DateTime.UtcNow,
			Money = 0,
			Name = "Wallet",
			Description = "Base wallet",
		};

		await _walletRepos.AddAsync(wallet);

		return wallet;
	}
}
