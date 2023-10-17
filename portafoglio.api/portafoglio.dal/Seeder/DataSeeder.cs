using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using portafoglio.bl.Entities;
using portafoglio.dal.Contextes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace portafoglio.dal.Seeder;
public class DataSeeder
{
	public static void Initialize(PortafoglioDbContext context)
	{
		var user = new User
		{
			Id = Guid.NewGuid(),
			Username = "tocco",
			Password = "123Stella"
		};

		var earingSuddivisions = new List<EarningSuddivision>
		{
			new EarningSuddivision
			{
				Id = Guid.NewGuid(),
				IdUser = user.Id,
				IsActive = true,
				Name = "Necessaries",
				Percentage = 50,
				Description = "All the needed payments"
			},
			new EarningSuddivision
			{
				Id = Guid.NewGuid(),
				IdUser = user.Id,
				IsActive = true,
				Name = "Fun",
				Percentage = 30,
				Description = "Fun payments"
			},
			new EarningSuddivision
			{
				Id = Guid.NewGuid(),
				IdUser = user.Id,
				IsActive = true,
				Name = "Savings",
				Percentage = 20,
				Description = "Money saved"
			},
		};

		var earning = new Earning
		{
			Id = Guid.NewGuid(),
			IdUser = user.Id,
			Value = 150000,
			Date = DateTime.Now,
		};

		var labels = earingSuddivisions
			.Select(e =>  
				new Label
				{
					Id = Guid.NewGuid(),
					IdEarningSuddivision = e.Id,
					Name = e.Name,
					Description = e.Description,
					IsActive = e.IsActive,
				})
			.ToList();

		var wallet = new Wallet
		{
			Id = Guid.NewGuid(),
			IdUser = user.Id,
			IsActive = true,
			LastUpdate = DateTime.Now,
			Money = 150000,
			Name = "Conto",
			Description = "Generic conto"
		};

		var isDbPopulated =
			context.Users.Any() ||
			context.EarningSuddivisions.Any() ||
			context.Earnings.Any() ||
			context.Labels.Any() ||
			context.Wallets.Any();

		if (isDbPopulated)
			return;

		context.Users.Add(user);
		context.EarningSuddivisions.AddRange(earingSuddivisions);
		context.Earnings.Add(earning);
		context.Labels.AddRange(labels);
		context.Wallets.Add(wallet);

		context.SaveChanges();
	}
}
