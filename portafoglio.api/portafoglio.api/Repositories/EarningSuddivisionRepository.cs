using portafoglio.api.Contextes;
using portafoglio.api.Models.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class EarningSuddivisionRepository : BaseLogicDeleteRepository<EarningSuddivision, EarningSuddivisionFilter>
{
	public EarningSuddivisionRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
