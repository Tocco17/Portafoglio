using portafoglio.dal.Contextes;
using portafoglio.bl.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class UserRepository : BaseLogicDeleteRepository<User, UserFilter>
{
	public UserRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
