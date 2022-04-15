using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MultipleDbContext.Data;
using MultipleDbContext.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DbOneContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbOneContext")));

builder.Services.AddDbContext<DbTwoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbTwoContext")));


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(b => b.RegisterModule(new AutoFacModule()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

public class AutoFacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DbOneContext>().As<BaseContext>();
        builder.RegisterType<DbTwoContext>().As<BaseContext>();
        builder.RegisterType<BookRepository>().As<IBookRepository>();

    }
}
