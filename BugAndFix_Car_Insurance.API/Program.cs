

using BugAndFix_Car_Insurance.API.DataLayer.Repository;
using BugAndFix_Car_Insurance.API.Filter.ActionFilters;
using BugAndFix_Car_Insurance.API.Filter.ExceptionFilter;
using BugAndFix_Car_Insurance.API.Infra.ExceptionHandler;
using BugAndFix_Car_Insurance.API.Infra.Generics;
using BugAndFix_Car_Insurance.API.Infra.Interface;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ActionFilterExample>();
builder.Services.AddScoped<CarValidateMadeInAndCapacityFilterAttribute>();

builder.Services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));

#region Repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<ICarRepository, CarRepository>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.

//app.ConfigureExceptionHandler();
//app.ConfigureCustomExceptionMiddleware();
app.UseHttpsRedirection();

//Routing

//app.MapGet("/cars", () =>
//{
//    return "List of All Cars";
//});

//app.MapGet("/cars/{id}", (int id) =>
//{
//    return $"Just one Car With ID : {id}";
//});

//app.MapPost("/cars", () =>
//{
//    return "Car is Created";
//});


//app.MapPut("/cars/{id}", (int id) =>
//{
//    return $"Car With ID {id} is Updated";
//});

//app.MapDelete("/cars/{id}", (int id) =>
//{
//    return $"Car With ID {id} is Deleted";
//});


app.MapControllers();


app.Run();


