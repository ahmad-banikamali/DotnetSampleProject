using System.Reflection;
using Application.Common.Mappers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Infrastructure;
using Repository.IRepositories;
using Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*sample project:
    ef core //
    dapper
    api caching
    authorization jwt roles
    unit of work //
    mediatR //
    signalR
    unit test
    integration test
    cors
    routing
    multi database
    fluent validation //
    */

builder.Services.AddMemoryCache();

builder.Services.AddDbContext<ApplicationDbContext>(optionsAction: optionsBuilder =>
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("sqlserver"))
);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var applicationAssembly = Assembly.Load(new AssemblyName(nameof(Application)));


builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssembly(applicationAssembly);


builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(applicationAssembly)
);


builder.Services.AddAutoMapper(
    typeof(ProductMapper),
    typeof(PriceHistoryMapper)
);


builder.Services.AddTransient<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
builder.Services.AddTransient<IProductRepository, ProductRepository<ApplicationDbContext>>();
builder.Services.AddTransient<IPriceHistoryRepository, PriceHistoryRepository<ApplicationDbContext>>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();