using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class CreditPaymentRepository : BaseRepository<CreditPayment, CreditPaymentFilter>
{
	public CreditPaymentRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
