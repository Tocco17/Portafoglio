using portafoglio.dal.Contextes;
using portafoglio.api.Models.Filters;
using portafoglio.bl.Entities;

namespace portafoglio.api.Repositories;

public class EarningRepository : BaseRepository<Earning, EarningFilter>
{
	public EarningRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
