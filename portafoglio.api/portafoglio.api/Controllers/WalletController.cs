using Microsoft.AspNetCore.Mvc;
using portafoglio.api.Models.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Models.Requests;
using portafoglio.api.Repositories;

namespace portafoglio.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalletController : BaseLogicDeleteController<Wallet, WalletFilter>
{
	public WalletController(IRepository<Wallet, WalletFilter> dbRepo, ILogicDeleteRepository<Wallet, WalletFilter> dbLogicDeleteRepo) : base(dbRepo, dbLogicDeleteRepo)
	{
	}
}
