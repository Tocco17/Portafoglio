using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class TransferRepository : BaseRepository<Transfer, TransferFilter>
{
	public TransferRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
