using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class DebtRepository : BaseRepository<Debt, DebtFilter>
{
	public DebtRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
