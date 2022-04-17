using System.Data;
using System.Reflection;
using DapperCrudAPIProject.Business.Filters;
using DapperCrudAPIProject.DataAccess.Repositories;
using DapperCrudAPIProject.Middlewares;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(option => option.Filters.Add(new ValidateFilter())).AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.Configure<ApiBehaviorOptions>(option =>
{

    option.SuppressModelStateInvalidFilter = true;
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserNotFoundFilter>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDbConnection>(sp
    => new NpgsqlConnection(builder.Configuration.GetConnectionString("PostgreSql")));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseGlobalExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();