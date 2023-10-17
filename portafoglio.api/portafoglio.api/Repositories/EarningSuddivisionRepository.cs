using portafoglio.dal.Contextes;
using portafoglio.bl.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class EarningSuddivisionRepository : BaseLogicDeleteRepository<EarningSuddivision, EarningSuddivisionFilter>
{
	public EarningSuddivisionRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
