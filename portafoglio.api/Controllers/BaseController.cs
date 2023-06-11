using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public abstract class BaseController<TEntity, TFilter> : ControllerBase
	where TEntity : BaseEntity
	where TFilter : IFilter<TEntity>
{
	protected readonly ILogger<TEntity> _logger;
	protected readonly IRepository<TEntity, TFilter> _dbRepo;

	public BaseController(ILogger<TEntity> logger, IRepository<TEntity, TFilter> dbRepo)
	{
		this._logger = logger;
		this._dbRepo = dbRepo;
	}

	[HttpGet("multiple")]
	public async virtual Task<ActionResult<IEnumerable<TEntity>>> GetByFilterAsync([FromQuery] TFilter filter)
	{
		var response = await _dbRepo.GetByFilterAsync(filter);

		if(response == null || response.Count() == 0)
			return NotFound();

		return Ok(response);
	}

	[HttpGet("{id}")]
	public async virtual Task<ActionResult<TEntity>> GetByIdAsync(int id)
	{
		var response = await _dbRepo.GetSingleByIdAsync(id);

		if (response == null)
			return NotFound();

		return response;
	}

	[HttpGet]
	public async virtual Task<ActionResult<TEntity>> GetSingleByFilterAsync(TFilter filter)
	{
		var response = await _dbRepo.GetSingleByFilterAsync(filter);

		if(response== null)
			return NotFound();

		return Ok(response);
	}

	[HttpPost]
	public async virtual Task<ActionResult> Post(TEntity entity)
	{
		await _dbRepo.CreateAsync(entity);
		return Created(nameof(GetByIdAsync), new { id = entity.Id });
	}

	[HttpPut("{id}")]
	public async virtual Task<ActionResult> Put(int id, TEntity entity)
	{
		if (id != entity.Id)
			return BadRequest("Ids not matching");

		if (await _dbRepo.UpdateAsync(entity))
			return NoContent();

		return NotFound();
	}

	[HttpDelete("{id}")]
	public async virtual Task<ActionResult> Delete(int id)
	{
		if (await _dbRepo.DeleteAsync(id))
			return NoContent();

		return NotFound();
	}
}

public abstract class LogicDeleteController<TEntity, TFilter> : BaseController<TEntity, TFilter>
	where TEntity : BaseLogicDeleteEntity
	where TFilter : IFilter<TEntity>
{
	protected LogicDeleteController(ILogger<TEntity> logger, IRepository<TEntity, TFilter> dbRepo) : base(logger, dbRepo)
	{
	}

	public async override Task<ActionResult> Delete(int id)
	{
		var entity = await _dbRepo.GetSingleByIdAsync(id);

		if(entity == null || !entity.Active)
			return NotFound();

		entity.Active = false;
		var result = await _dbRepo.UpdateAsync(entity);

		return result 
			? Ok(result) 
			: StatusCode(StatusCodes.Status500InternalServerError, "Element not deleted");
	}

#if DEBUG
	[HttpDelete("complete/{id}")]
	public async Task<ActionResult> CompleteDelete(int id)
	{
		if (await _dbRepo.DeleteAsync(id))
			return NoContent();

		return NotFound();
	}
#endif
}