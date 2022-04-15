using DL;
using BL;
using Serilog;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog(
    (ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.File("../logs/log.txt", rollingInterval: RollingInterval.Day)
);

//Ensures that the JSON serialization uses PascalCasing in its keys
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//creates an IMemory Cache that lets us cache our results
builder.Services.AddMemoryCache();

builder.Services.AddScoped<IRepo>(ctx => new DataStorage(builder.Configuration.GetConnectionString("SLDB")));
builder.Services.AddScoped<IBL, BusinessL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
