using HD.Station.FoodOrder;
using NLog;

var builder = WebApplication.CreateBuilder(args);

//Set configure Nlog


LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));




// Add services to the container.

builder.Services.ConfigureServices();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureCores();
builder.Services.ConfigurePostgreSQL(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
