﻿using portafoglio.api.Contextes;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

namespace portafoglio.api.Repositories;

public class TransactionRepository : BaseRepository<Transaction, TransactionFilter>
{
	public TransactionRepository(PortafoglioDbContext dbContext) : base(dbContext)
	{
	}
}
