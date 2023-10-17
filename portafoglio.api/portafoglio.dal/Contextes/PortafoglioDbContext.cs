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


public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PortafoglioDbContext>
{
	public PortafoglioDbContext CreateDbContext(string[] args)
	{
		IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MyCookingMaster.API/appsettings.json").Build();
		var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
		var connectionString = configuration.GetConnectionString("DatabaseConnection");
		builder.UseSqlServer(connectionString);
		return new ApplicationDbContext(builder.Options);
	}
}
