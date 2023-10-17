using portafoglio.dal.Contextes;
using portafoglio.bl.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class LabelRepository : BaseLogicDeleteRepository<Label, LabelFilter>
{
	public LabelRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
