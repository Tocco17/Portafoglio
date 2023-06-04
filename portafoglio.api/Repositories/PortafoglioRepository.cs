using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class PortafoglioRepository : BaseRepository<Portafoglio, PortafoglioFilter>
{
	public PortafoglioRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
