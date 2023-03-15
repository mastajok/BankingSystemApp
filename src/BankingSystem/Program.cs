using BankingSystem.Contracts;
using BankingSystem.Data;
using BankingSystem.DataAccess.Contracts;
using BankingSystem.DataAccess.Repositories;
using BankingSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BankingSystemDbContext>(
    options => options.UseSqlServer("name=ConnectionStrings:Default"));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserAccountRepository, UserAccountRepository>();

builder.Services.AddTransient<IUserAccountOperationService, UserAccountOperationService>();
builder.Services.AddTransient<IUserAccountService, UserAccountService>();
builder.Services.AddTransient<IWithdrawValidationService, WithdrawValidationService>();
builder.Services.AddTransient<IDepositValidationService, DepositValidationService>();
    

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();

app.Run();
