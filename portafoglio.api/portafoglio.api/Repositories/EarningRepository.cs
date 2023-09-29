using portafoglio.api.Contextes;
using portafoglio.api.Models.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class EarningRepository : BaseRepository<Earning, EarningFilter>
{
	public EarningRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
