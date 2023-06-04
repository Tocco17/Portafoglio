using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class DebtPaymentRepository : BaseRepository<DebtPayment, DebtPaymentFilter>
{
	public DebtPaymentRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
