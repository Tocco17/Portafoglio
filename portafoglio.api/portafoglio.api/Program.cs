using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using portafoglio.api.Contextes;

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
