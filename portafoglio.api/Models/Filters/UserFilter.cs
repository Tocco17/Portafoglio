using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class UserFilter : IFilter<User>
{
	public string? Username { get; set; } = null;
	public string? Password { get; set; } = null;

	public IQueryable<User> GetFilteredQuery(IQueryable<User> baseQuery)
	{
		var query = baseQuery.AsQueryable();

		if (!string.IsNullOrEmpty(Username))
			query = query.Where(x => x.Username == Username);

		if (!string.IsNullOrEmpty(Password))
			query = query.Where(x => x.Password == Password);

		return query;
	}
}
