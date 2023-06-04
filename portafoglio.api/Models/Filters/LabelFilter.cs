using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public class LabelFilter : IFilter<Label>
{
	public IQueryable<Label> GetFilteredQuery(IQueryable<Label> baseQuery)
	{
		return baseQuery;
	}
}
