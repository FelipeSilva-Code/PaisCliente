using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TesteCometrix.Server.Middlewares;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

// Add services to the container.
services.AddControllers(options => 
{ 
    options.Filters.Add<ValidateModelStateFilter>();
});

services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
services.AddFluentValidationAutoValidation();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddCors();

builder.ApiRegister();

services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x =>
    x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.UseMiddleware(typeof(TratamentoExceptionMiddleware));

app.Run();

