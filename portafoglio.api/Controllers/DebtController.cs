﻿using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class DebtController : LogicDeleteController<Debt, DebtFilter>
{
	public DebtController(ILogger<Debt> logger, IRepository<Debt, DebtFilter> dbRepo) : base(logger, dbRepo)
	{
	}
}
