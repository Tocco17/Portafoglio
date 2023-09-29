using portafoglio.api.Models.Entities;

namespace portafoglio.api.Models.Filters;

public interface IFilter<TEntity> where TEntity : BaseEntity
{
	int? From { get; set; }
	int? Size { get; set; }

	IQueryable<TEntity> GetOptionsFilterQuery(IQueryable<TEntity> baseQuery);
}

public abstract class BaseFilter<TEntity> : IFilter<TEntity> where TEntity : BaseEntity
{
	public int? From { get; set; } = null;
	public int? Size { get; set; } = null;

	public virtual IQueryable<TEntity> GetOptionsFilterQuery(IQueryable<TEntity> baseQuery)
	{
		var size = this.Size ?? 0;
		var from = this.From ?? 1;
		var page = size * (from - 1);

		if (page < 0) page = 0;

		var query = baseQuery.Skip(page);

		return this.Size != null
			? query.Take(this.Size.Value)
			: query;
	}
}
