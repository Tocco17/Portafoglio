using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class UserFilter : IFilter<User>
{
	public IQueryable<User> GetFilteredQuery(IQueryable<User> baseQuery)
	{
		return baseQuery;
	}
}
