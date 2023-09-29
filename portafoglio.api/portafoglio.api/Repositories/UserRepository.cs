using portafoglio.api.Contextes;
using portafoglio.api.Models.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class UserRepository : BaseLogicDeleteRepository<User, UserFilter>
{
	public UserRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
