using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Models.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;
public abstract class BaseController<TEntity, TFilter> : ControllerBase
	where TEntity : BaseEntity
	where TFilter : IFilter<TEntity>
{
	protected readonly IRepository<TEntity, TFilter> _dbRepo;

	public BaseController(IRepository<TEntity, TFilter> dbRepo)
	{
		this._dbRepo = dbRepo;
	}

	[HttpGet]
	public async virtual Task<ActionResult<IEnumerable<TEntity>>> Get([FromQuery] TFilter? filter)
	{
		return Ok(await _dbRepo.GetAsync(filter));
	}

	[HttpGet("{id}")]
	public async virtual Task<ActionResult<TEntity>> GetById(Guid id)
	{
		var entity = await _dbRepo.GetByIdAsync(id);

		if (entity == null)
			return NotFound();

		return Ok(entity);
	}

	[HttpGet("count")]
	public async virtual Task<ActionResult<int>> GetCount([FromQuery] TFilter? filter)
	{
		var count = await _dbRepo.GetCountAsync(filter);
		return Ok(count);
	}

	[HttpGet("single")]
	public async virtual Task<ActionResult<TEntity>> GetSingleOrDefault([FromQuery] TFilter filter)
	{
		var entity = await _dbRepo.GetSingleOrDefaultAsync(filter);

		if (entity == null)
			return NotFound();

		return Ok(entity);
	}

	[HttpGet("multiple")]
	public async virtual Task<ActionResult<TEntity>> GetById([FromQuery] IEnumerable<Guid> ids)
	{
		var entities = await _dbRepo.GetByIdAsync(ids);

		if (entities == null || entities.Count() == 0)
			return NotFound();

		return Ok(entities);
	}

	[HttpPost]
	public async virtual Task<ActionResult<Guid>> Post(TEntity entity)
	{
		var guid = await _dbRepo.AddAsync(entity);
		return Ok(guid);
	}

	[HttpPost("multiple")]
	public async virtual Task<ActionResult<IEnumerable<Guid>>> Post(IEnumerable<TEntity> entities)
	{
		var guids = await _dbRepo.AddAsync(entities);
		return Ok(guids);
	}


	[HttpPut]
	public async virtual Task<ActionResult<int>> Put(TEntity entity)
	{
		var count = await _dbRepo.UpdateAsync(entity);
		return count == 1 ? Ok(count) : NotFound();
	}

	[HttpPut("multiple")]
	public async virtual Task<ActionResult<int>> Put(IEnumerable<TEntity> entities)
	{
		var count = await _dbRepo.UpdateAsync(entities);
		return count == 1 ? Ok(count) : NotFound();
	}

	[HttpDelete]
	public async virtual Task<ActionResult<int>> Delete(Guid id)
	{
		var count = await _dbRepo.DeleteAsync(id);
		return count == 1 ? Ok(count) : NotFound();
	}

	[HttpDelete("multiple")]
	public async virtual Task<ActionResult<int>> Delete(IEnumerable<Guid> ids)
	{
		var count = await _dbRepo.DeleteAsync(ids);
		return count == ids.Count() ? Ok(count) : NotFound();
	}
}

public abstract class BaseLogicDeleteController<TEntity, TFilter> : BaseController<TEntity, TFilter>
	where TEntity : LogicDeleteEntity
	where TFilter : ILogicDeleteFilter<TEntity>
{
	protected readonly ILogicDeleteRepository<TEntity, TFilter> _dbLogicDeleteRepo;

	public BaseLogicDeleteController(
		IRepository<TEntity, TFilter> dbRepo,
		ILogicDeleteRepository<TEntity, TFilter> dbLogicDeleteRepo) : base(dbRepo)
	{
		this._dbLogicDeleteRepo = dbLogicDeleteRepo;
	}

	[HttpGet("active")]
	public async virtual Task<ActionResult<IEnumerable<TEntity>>> GetActive([FromQuery] TFilter? filter)
	{
		return Ok(await _dbLogicDeleteRepo.GetActiveAsync(filter));
	}

	[HttpGet("active/single")]
	public async virtual Task<ActionResult<TEntity>> GetActiveSingleOrDefault([FromQuery] TFilter? filter)
	{
		return Ok(await _dbLogicDeleteRepo.GetActiveSingleOrDefaultAsync(filter));
	}

	[HttpPost("active/{id}")]
	public async virtual Task<ActionResult> PostActive(Guid id)
	{
		var count = await _dbLogicDeleteRepo.ActivateLogicallyAsync(id);
		return count == 1 ? Ok(count) : NotFound();
	}

	[HttpPost("active/multiple")]
	public async virtual Task<ActionResult<int>> PostMultipleActive(IEnumerable<Guid> ids)
	{
		var count = await _dbLogicDeleteRepo.ActivateLogicallyAsync(ids);
		return count == ids.Count() ? Ok(count) : NotFound();
	}

	[HttpDelete("active/{id}")]
	public async virtual Task<ActionResult> DeleteActive(Guid id)
	{
		var count = await _dbLogicDeleteRepo.DeleteLogicallyAsync(id);
		return count == 1 ? Ok(count) : NotFound();
	}

	[HttpDelete("active/multiple")]
	public async virtual Task<ActionResult<int>> DeleteMultipleActive(IEnumerable<Guid> ids)
	{
		var count = await _dbLogicDeleteRepo.DeleteLogicallyAsync(ids);
		return count == ids.Count() ? Ok(count) : NotFound();
	}

	[HttpGet("deactive")]
	public async virtual Task<ActionResult<IEnumerable<TEntity>>> GetDeActive([FromQuery] TFilter? filter)
	{
		return Ok(await _dbLogicDeleteRepo.GetDeActiveAsync(filter));
	}

	[HttpGet("deactive/single")]
	public async virtual Task<ActionResult<TEntity>> GetDeActiveSingleOrDefault([FromQuery] TFilter? filter)
	{
		return Ok(await _dbLogicDeleteRepo.GetDeActiveSingleOrDefaultAsync(filter));
	}



}
