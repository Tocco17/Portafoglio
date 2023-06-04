using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public abstract class BaseRepository<TEntity, TFilter> : IRepository<TEntity, TFilter>
	where TEntity : BaseEntity
	where TFilter : IFilter<TEntity>
{

	protected readonly PortafoglioDbContext _dbContext;
	protected readonly DbSet<TEntity> _dbSet;

	public BaseRepository(PortafoglioDbContext dbContext)
	{
		_dbContext = dbContext;
		_dbSet = dbContext.Set<TEntity>();
	}

	public async virtual Task<bool> CreateAsync(TEntity entity)
	{
		await _dbSet.AddAsync(entity);
		var count = await _dbContext.SaveChangesAsync();

		return count == 1;
	}

	public async virtual Task<bool> DeleteAsync(int id)
	{
		var count = await _dbSet
			.Where(x => x.Id == id)
			.ExecuteDeleteAsync();

		return count == 1;
	}

	public async virtual Task<IEnumerable<TEntity>> GetByFilterAsync(TFilter? filter)
	{
		var baseQuery = _dbSet.AsQueryable();

		if (filter == null)
			return await baseQuery.ToListAsync();

		var query = filter.GetFilteredQuery(baseQuery);
		return query.ToList();
	}

	public Task<TEntity?> GetSingleByFilterAsync(TFilter filter)
	{
		var query = filter.GetFilteredQuery(_dbSet.AsQueryable());
		return query.FirstOrDefaultAsync();
	}

	public async virtual Task<TEntity?> GetSingleByIdAsync(int id)
	{
		return await _dbSet.SingleOrDefaultAsync(item => item.Id == id);
	}

	public async virtual Task<bool> UpdateAsync(TEntity entity)
	{
		if (!await _dbSet.AnyAsync(x => x.Id == entity.Id))
			return false;

		_dbSet.Update(entity);
		await _dbContext.SaveChangesAsync();
		return true;
	}
}