using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class FrequentPaymentPaymentRepository : BaseRepository<FrequentPaymentPayment, FrequentPaymentPaymentFilter>
{
	public FrequentPaymentPaymentRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
