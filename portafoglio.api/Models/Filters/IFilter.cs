using portafoglio.api.Entities;

namespace portafoglio.api.Models.Filters;

public interface IFilter<TEntity>
	where TEntity : BaseEntity
{
	public IQueryable<TEntity> GetFilteredQuery(IQueryable<TEntity> baseQuery);
}
