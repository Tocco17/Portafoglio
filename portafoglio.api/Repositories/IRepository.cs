using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public interface IRepository<TEntity, TFilter>
	where TEntity : BaseEntity
	where TFilter : IFilter<TEntity>
{
	public Task<bool> CreateAsync(TEntity entity);
	public Task<bool> UpdateAsync(TEntity entity);
	public Task<bool> DeleteAsync(int id);
	public Task<TEntity?> GetSingleByIdAsync(int id);
	public Task<TEntity?> GetSingleByFilterAsync(TFilter filter);
	public Task<IEnumerable<TEntity>> GetByFilterAsync(TFilter? filter);
}
