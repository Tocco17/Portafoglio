using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class LabelRepository : BaseRepository<Label, LabelFilter>
{
	public LabelRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
