using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using portafoglio.bl.Entities;

namespace portafoglio.dal.Contextes;

public class PortafoglioDbContext : DbContext
{
	public PortafoglioDbContext(DbContextOptions<PortafoglioDbContext> options) : base(options)
	{
	}

	public virtual DbSet<Earning> Earnings { get; set; } = null!;
	public virtual DbSet<EarningSuddivision> EarningSuddivisions { get; set; } = null!;
	public virtual DbSet<Label> Labels { get; set; } = null!;
	public virtual DbSet<Transaction> Transactions { get; set; } = null!;
	public virtual DbSet<User> Users { get; set; } = null!;
	public virtual DbSet<Wallet> Wallets { get; set; } = null!;

}