using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class UserRepository : BaseRepository<User, UserFilter>
{
	public UserRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
