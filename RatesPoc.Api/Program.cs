using RatesPoc.Api.BusinessLayer;
using RatesPoc.Api.Middleware;
using RatesPoc.Api.Services;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IRatesEnvironment, RatesEnvironment>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var locatorHost = Environment.GetEnvironmentVariable("LOCATOR_HOST");
var locatorPort = Environment.GetEnvironmentVariable("LOCATOR_PORT");
var locatorUri = $"http://{locatorHost}:{locatorPort}";

builder.Services.AddHttpClient<IRatesBusinessService, RatesBusinessService>(c =>
    c.BaseAddress = new Uri(locatorUri)
)
.AddPolicyHandler(PollyExtensions.GetRetryPolicy())
.AddPolicyHandler(PollyExtensions.GetCircuitBreakerPolicy());

// NOTE: DB connections should be initialized here, same as above HTTP connections
//builder.Services.AddDbContext<ShoppingBasketDbContext>(options =>
//{
//    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
//});

var app = builder.Build();

var assemblyName = typeof(Program).Assembly.GetName().Name;
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .Enrich.WithProperty("Assembly", assemblyName)
    .WriteTo.Console()
    .CreateLogger();

app.UseMiddleware<CustomExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

