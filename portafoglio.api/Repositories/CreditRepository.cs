using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class CreditRepository : BaseRepository<Credit, CreditFilter>
{
	public CreditRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
