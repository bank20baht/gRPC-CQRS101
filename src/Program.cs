using GrpcCqrs101.Services;
using Microsoft.EntityFrameworkCore;
using GrpcCqrs101.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MS_SQL_URL"));
});
var app = builder.Build();

app.MapGrpcService<GreeterService>();
app.MapGrpcService<CustomerService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
