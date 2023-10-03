using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using portafoglio.api.Contextes;
using portafoglio.api.Models.Entities;
using portafoglio.api.Models.Filters;
using portafoglio.api.Repositories;
using portafoglio.api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var okDoms = new List<string> { "localhost" };
builder.Services.AddCors(opt =>
{
	opt.AddDefaultPolicy(policy =>
		policy.SetIsOriginAllowed(origin => okDoms.Contains(new Uri(origin).Host))
			.AllowAnyHeader()
			.AllowAnyMethod());
});

builder.Services.AddControllers()
	.AddJsonOptions(opt =>
	{
		opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
		opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
	.AddDbContext<PortafoglioDbContext>(options =>
	options
		.UseSqlite(
			Environment.GetEnvironmentVariable("DefaultConnection") ??
			builder.Configuration.GetConnectionString("DefaultConnection")
		)
	);

builder.Services.AddScoped<IRepository<Earning, EarningFilter>, EarningRepository>();
builder.Services.AddScoped<IRepository<EarningSuddivision, EarningSuddivisionFilter>, EarningSuddivisionRepository>();
builder.Services.AddScoped<IRepository<Label, LabelFilter>, LabelRepository>();
builder.Services.AddScoped<IRepository<Transaction, TransactionFilter>, TransactionRepository>();
builder.Services.AddScoped<IRepository<User, UserFilter>, UserRepository>();
builder.Services.AddScoped<IRepository<Wallet, WalletFilter>, WalletRepository>();

builder.Services.AddScoped<ILogicDeleteRepository<EarningSuddivision, EarningSuddivisionFilter>, EarningSuddivisionRepository>();
builder.Services.AddScoped<ILogicDeleteRepository<Label, LabelFilter>, LabelRepository>();
builder.Services.AddScoped<ILogicDeleteRepository<User, UserFilter>, UserRepository>();
builder.Services.AddScoped<ILogicDeleteRepository<Wallet, WalletFilter>, WalletRepository>();

builder.Services.AddScoped<EarningRepository>();
builder.Services.AddScoped<EarningSuddivisionRepository>();
builder.Services.AddScoped<LabelRepository>();
builder.Services.AddScoped<TransactionRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<WalletRepository>();

builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
