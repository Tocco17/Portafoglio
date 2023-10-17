using portafoglio.dal.Contextes;
using portafoglio.bl.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class TransactionRepository : BaseRepository<Transaction, TransactionFilter>
{
	public TransactionRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
