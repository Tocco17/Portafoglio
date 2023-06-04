using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using portafoglio.api.Contextes;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using portafoglio.api.Repositories;
using portafoglio.api.Entities;
using portafoglio.api.Models.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt =>
{
	opt.AddDefaultPolicy(policy =>
		policy.SetIsOriginAllowed(origin =>
			new Uri(origin).Host == "localhost")
				.AllowAnyHeader()
				.AllowAnyMethod());
});

builder.Services.AddControllers()
	.AddJsonOptions(opt =>
	{
		opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlite<PortafoglioDbContext>("Data Source=Portafoglio.db");

builder.Services.AddScoped<IRepository<Credit, CreditFilter>, CreditRepository>();
builder.Services.AddScoped<IRepository<CreditPayment, CreditPaymentFilter>, CreditPaymentRepository>();
builder.Services.AddScoped<IRepository<Debt, DebtFilter>, DebtRepository>();
builder.Services.AddScoped<IRepository<DebtPayment, DebtPaymentFilter>, DebtPaymentRepository>();
builder.Services.AddScoped<IRepository<FrequentPayment, FrequentPaymentFilter>, FrequentPaymentRepository>();
builder.Services.AddScoped<IRepository<FrequentPaymentPayment, FrequentPaymentPaymentFilter>, FrequentPaymentPaymentRepository>();
builder.Services.AddScoped<IRepository<Label, LabelFilter>, LabelRepository>();
builder.Services.AddScoped<IRepository<Portafoglio, PortafoglioFilter>, PortafoglioRepository>();
builder.Services.AddScoped<IRepository<Subscription, SubscriptionFilter>, SubscriptionRepository>();
builder.Services.AddScoped<IRepository<SubscriptionPayment, SubscriptionPaymentFilter>, SubscriptionPaymentRepository>();
builder.Services.AddScoped<IRepository<Transaction, TransactionFilter>, TransactionRepository>();
builder.Services.AddScoped<IRepository<Transfer, TransferFilter>, TransferRepository>();
builder.Services.AddScoped<IRepository<User, UserFilter>, UserRepository>();


builder.Services.AddApiVersioning(opt =>
{
	opt.DefaultApiVersion = new ApiVersion(1, 0);
	opt.AssumeDefaultVersionWhenUnspecified = true;
	opt.ReportApiVersions = true;
	opt.ApiVersionReader = ApiVersionReader.Combine(
		new UrlSegmentApiVersionReader(),
		new HeaderApiVersionReader("x-api-version"),
		new MediaTypeApiVersionReader("x-api-version")
	);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();