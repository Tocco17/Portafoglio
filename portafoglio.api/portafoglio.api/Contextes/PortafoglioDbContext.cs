using Microsoft.EntityFrameworkCore;
using portafoglio.api.Models.Entities;

namespace portafoglio.api.Contextes;

public class PortafoglioDbContext : DbContext
{
	public PortafoglioDbContext(DbContextOptions<PortafoglioDbContext> options) : base(options)
	{
	}

	public DbSet<Earning> Earnings { get; set; } = null!;
	public DbSet<EarningSuddivision> EarningSuddivisions { get; set; } = null!;
	public DbSet<Label> Labels { get; set; } = null!;
	public DbSet<Transaction> Transactions { get; set; } = null!;
	public DbSet<User> Users { get; set; } = null!;
	public DbSet<Wallet> Wallets { get; set; } = null!;

}
