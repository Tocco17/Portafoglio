using Microsoft.EntityFrameworkCore;
using portafoglio.api.Entities;

namespace portafoglio.api.Contextes;

public class PortafoglioDbContext : DbContext
{
	public PortafoglioDbContext(DbContextOptions<PortafoglioDbContext> options) : base(options)
	{
	}

	public DbSet<Credit> Credits { get; set; }
	public DbSet<CreditPayment> CreditPayments { get; set; }
	public DbSet<Debt> Debts { get; set; }
	public DbSet<DebtPayment> DebtPayments { get; set; }
	public DbSet<FrequentPayment> FrequentPayments { get; set; }
	public DbSet<FrequentPayment_Payment> FrequentPayment_Payments { get; set; }
	public DbSet<Label> Labels { get; set; }
	public DbSet<Portafoglio> Portafoglios { get; set; }
	public DbSet<Subscription> Subscriptions { get; set; }
	public DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }
	public DbSet<Transaction> Transactions { get; set; }
	public DbSet<Transfer> Transfers { get; set; }
	public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		ManageEnumConversionBuilder(modelBuilder);
	}

	private void ManageEnumConversionBuilder(ModelBuilder modelBuilder)
	{
		//CONTRACT TYPE
		modelBuilder.Entity<Subscription>()
			.Property(x => x.Periodicity)
			.HasConversion(
				v => v.ToString(),
				v => Enum.Parse<PeriodicityPayment>(v)
			);
	}

}
