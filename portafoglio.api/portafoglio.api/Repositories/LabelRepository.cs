using portafoglio.api.Contextes;
using portafoglio.api.Models.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class LabelRepository : BaseLogicDeleteRepository<Label, LabelFilter>
{
	public LabelRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
