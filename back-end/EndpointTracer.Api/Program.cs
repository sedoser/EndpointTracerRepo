using EndpointTracer.Biz;
using EndpointTracer.DataAccess;
using EndpointTracer.DataAccess.Repositories;
using EndpointTracer.DataAccess.Uow;
using EndpointTracer.Model;
using EndpointTracer.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped(typeof(IRepository<>),typeof(EfEntityRepositoryBase<>));
builder.Services.AddScoped<IRepository<ExternalDp>, EfEntityRepositoryBase<ExternalDp>>();
builder.Services.AddScoped<IExternalDpService, ExternalDpService>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddDbContext<EndpointTracerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MssqlDb"),
    x => x.MigrationsAssembly("EndpointTracer.DataAccess")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//dotnet ef migrations add initial_create --project "\EndpointTracer.DataAccess" --startup-project "\EndpointTracer.Api"
//dotnet ef database update --project "\EndpointTracer.DataAccess" --startup-project "\EndpointTracer.Api"
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

