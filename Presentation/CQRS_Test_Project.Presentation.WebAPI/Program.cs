using CQRS_Test_Project.Core.Application;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Validations.User;
using CQRS_Test_Project.Infrastructure.Persistence.Context;
using CQRS_Test_Project.Infrastructure.Persistence.Repository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(conf=>conf.RegisterValidatorsFromAssemblyContaining<CreateUserCommandRequestValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAplicationLayerServices();
builder.Services.AddDbContext<CqrsContext>();

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
