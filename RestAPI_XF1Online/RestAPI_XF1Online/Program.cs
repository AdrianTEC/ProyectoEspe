using Microsoft.EntityFrameworkCore;
using RestAPI_XF1Online.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IDataRepo, SqlRepo>();
builder.Services.AddDbContext<XF1OnlineContext>(opt => opt.UseSqlServer
    (builder.Configuration.GetConnectionString("SqlConnection")));

var app = builder.Build();

app.UseCors(builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
