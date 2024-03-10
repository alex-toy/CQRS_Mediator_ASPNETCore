using AutoMapper;
using FormulaOne.Api.Services.Achievements;
using FormulaOne.Data.Repositories.Achievements;
using FormulaOne.Data.Repositories.Drivers;
using FormulaOne.Data.UnitOfWorks;
using FormulaOne.Entities.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAchievementRepo, AchievementRepo>();
builder.Services.AddScoped<IDriverRepo, DriverRepo>();

builder.Services.AddScoped<IAchievementService, AchievementService>();





var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
