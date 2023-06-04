using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class FrequentPaymentRepository : BaseRepository<FrequentPayment, FrequentPaymentFilter>
{
	public FrequentPaymentRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
