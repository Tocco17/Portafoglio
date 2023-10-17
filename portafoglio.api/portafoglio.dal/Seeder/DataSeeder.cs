using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using portafoglio.bl.Entities;
using portafoglio.dal.Contextes;

namespace portafoglio.dal.Seeder;
public class DataSeeder
{
	public static void Initialize(PortafoglioDbContext context)
	{
		if (!context.Users.Any())
		{
			var users = new List<User>()
			{
				new User { Username = "Tocco", Password = "drowssap1" },
			};
			context.Users.AddRange(users);
			context.SaveChanges();
		}
	}
}
