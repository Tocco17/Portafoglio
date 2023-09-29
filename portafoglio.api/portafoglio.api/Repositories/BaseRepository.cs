using Microsoft.EntityFrameworkCore;
using portafoglio.api.Contextes;
using portafoglio.api.Models.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public interface IRepository<TEntity, TFilter>
	where TEntity : BaseEntity
	where TFilter : IFilter<TEntity>
{
	Task<IEnumerable<TEntity>> GetAsync(TFilter? filter);
	Task<TEntity?> GetSingleOrDefaultAsync(TFilter? filter);
	Task<IEnumerable<TEntity>> GetByIdAsync(IEnumerable<Guid> idList);
	Task<TEntity> GetByIdAsync(Guid id);
	Task<int> GetCountAsync(TFilter? filter);

	Task<Guid> AddAsync(TEntity entity);
	Task<IEnumerable<Guid>> AddAsync(IEnumerable<TEntity> entities);

	Task<int> UpdateAsync(TEntity entity);
	Task<int> UpdateAsync(IEnumerable<TEntity> entities);

	Task<int> DeleteAsync(Guid id);
	Task<int> DeleteAsync(IEnumerable<Guid> ids);
}

public interface ILogicDeleteRepository<TEntity, TFilter> : IRepository<TEntity, TFilter>
	where TEntity : LogicDeleteEntity
	where TFilter : ILogicDeleteFilter<TEntity>
{
	Task<IEnumerable<TEntity>> GetActiveAsync(TFilter? filter);
	Task<TEntity?> GetActiveSingleOrDefaultAsync(TFilter? filter);
	Task<IEnumerable<TEntity>> GetDeActiveAsync(TFilter? filter);
	Task<TEntity?> GetDeActiveSingleOrDefaultAsync(TFilter? filter);
	Task<int> ActivateLogicallyAsync(Guid id);
	Task<int> ActivateLogicallyAsync(IEnumerable<Guid> ids);
	Task<int> DeleteLogicallyAsync(Guid id);
	Task<int> DeleteLogicallyAsync(IEnumerable<Guid> ids);
}

public abstract class BaseRepository<TEntity, TFilter> : IRepository<TEntity, TFilter>
	where TEntity : BaseEntity
	where TFilter : IFilter<TEntity>, new()
{
	protected readonly PortafoglioDbContext _dbContext;
	protected readonly DbSet<TEntity> _dbSet;

	public BaseRepository(PortafoglioDbContext dbContext)
	{
		_dbContext = dbContext;
		_dbSet = dbContext.Set<TEntity>();
	}

	public virtual async Task<Guid> AddAsync(TEntity entity)
	{
		await _dbSet.AddAsync(entity);
		await _dbContext.SaveChangesAsync();
		return entity.Id;
	}

	public virtual async Task<IEnumerable<Guid>> AddAsync(IEnumerable<TEntity> entities)
	{
		await _dbSet.AddRangeAsync(entities);
		await _dbContext.SaveChangesAsync();
		return entities.Select(x => x.Id);
	}

	public virtual async Task<int> DeleteAsync(Guid id)
	{
		return await _dbSet
			.Where(x => x.Id == id)
			.ExecuteDeleteAsync();
	}

	public virtual async Task<int> DeleteAsync(IEnumerable<Guid> ids)
	{
		return await _dbSet
			.Where(x => ids.Any(id => id.Equals(x.Id)))
			.ExecuteDeleteAsync();
	}

	public virtual async Task<IEnumerable<TEntity>> GetAsync(TFilter? filter)
	{
		var query = GetFilteredQuery(filter);
		return await query.ToListAsync();
	}

	public virtual async Task<IEnumerable<TEntity>> GetByIdAsync(IEnumerable<Guid> idList)
	{
		return await _dbSet.Where(x => idList.Any(id => id.Equals(x))).ToListAsync();
	}

	public virtual async Task<TEntity> GetByIdAsync(Guid id)
	{
		return await _dbSet.SingleAsync(x => x.Id.Equals(id));
	}

	public virtual async Task<int> GetCountAsync(TFilter? filter)
	{
		var query = GetFilteredQuery(filter);
		return await query.CountAsync();
	}

	public virtual async Task<TEntity?> GetSingleOrDefaultAsync(TFilter? filter)
	{
		var query = GetFilteredQuery(filter);
		return await query.SingleOrDefaultAsync();
	}

	public virtual async Task<int> UpdateAsync(TEntity entity)
	{
		if (!await _dbSet.AnyAsync(x => x.Id.Equals(entity.Id)))
			throw new Exception("Entity not found.");

		_dbSet.Update(entity);
		return await _dbContext.SaveChangesAsync();
	}

	public virtual async Task<int> UpdateAsync(IEnumerable<TEntity> entities)
	{
		var ok = entities.All(entity =>
		{
			return _dbSet.Any(x => x.Id.Equals(entity.Id));
		});

		if (!ok)
			throw new Exception("Some entities has not been found.");

		_dbSet.UpdateRange(entities);
		return await _dbContext.SaveChangesAsync();
	}

	protected virtual IQueryable<TEntity> GetFilteredQuery(TFilter? filter)
	{
		var baseQuery = _dbSet.AsQueryable();
		var query = filter?.GetOptionsFilterQuery(baseQuery) ?? baseQuery;
		return query;
	}
}

public abstract class BaseLogicDeleteRepository<TEntity, TFilter> : BaseRepository<TEntity, TFilter>, ILogicDeleteRepository<TEntity, TFilter>
	where TEntity : LogicDeleteEntity
	where TFilter : ILogicDeleteFilter<TEntity>, new()
{
	protected BaseLogicDeleteRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}

	public virtual async Task<int> ActivateLogicallyAsync(Guid id)
	{
		var entity = await GetByIdAsync(id);
		entity.IsActive = true;
		return await UpdateAsync(entity);
	}

	public virtual async Task<int> ActivateLogicallyAsync(IEnumerable<Guid> ids)
	{
		var entities = await GetByIdAsync(ids);

		foreach (var entity in entities)
		{
			entity.IsActive = true;
		}

		return await UpdateAsync(entities);
	}

	public virtual async Task<int> DeleteLogicallyAsync(Guid id)
	{
		var entity = await GetByIdAsync(id);
		entity.IsActive = false;
		return await UpdateAsync(entity);
	}

	public virtual async Task<int> DeleteLogicallyAsync(IEnumerable<Guid> ids)
	{
		var entities = await GetByIdAsync(ids);

		foreach (var entity in entities)
		{
			entity.IsActive = false;
		}

		return await UpdateAsync(entities);
	}

	public async Task<IEnumerable<TEntity>> GetActiveAsync(TFilter? filter)
	{
		filter ??= new TFilter();
		filter.IsActive = true;
		var query = GetFilteredQuery(filter);
		return await query.ToListAsync();
	}

	public async Task<TEntity?> GetActiveSingleOrDefaultAsync(TFilter? filter)
	{
		filter ??= new TFilter();
		filter.IsActive = true;
		var query = GetFilteredQuery(filter);
		return await query.SingleOrDefaultAsync();
	}

	public async Task<IEnumerable<TEntity>> GetDeActiveAsync(TFilter? filter)
	{
		filter ??= new TFilter();
		filter.IsActive = false;
		var query = GetFilteredQuery(filter);
		return await query.ToListAsync();
	}

	public async Task<TEntity?> GetDeActiveSingleOrDefaultAsync(TFilter? filter)
	{
		filter ??= new TFilter();
		filter.IsActive = false;
		var query = GetFilteredQuery(filter);
		return await query.SingleOrDefaultAsync();
	}
}
