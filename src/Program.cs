using GrpcCqrs101.Services;
using GrpcCqrs101.Repository;
using GrpcCqrs101.IRepository;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<ExceptionHandlingInterceptor>();
});
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssemblyContaining<AddCustomerCommandValidator>();

//  MediatR pipeline behaviors
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingPipelineBehavior<,>));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MS_SQL_URL"));
});

var app = builder.Build();

app.MapGrpcService<CustomerService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
