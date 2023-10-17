using portafoglio.dal.Contextes;
using portafoglio.bl.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class WalletRepository : BaseLogicDeleteRepository<Wallet, WalletFilter>
{
	public WalletRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
