using Helper.AppSettings;
using Microsoft.EntityFrameworkCore;
using Model.Context;
using NewsAppWebapplication_IServices;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Data base
var connectionString = builder.Configuration["ConnectionString:Credentials"];
builder.Services.AddDbContext<Informia_Context>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
#endregion

#region Get Data From AppSetting
AppsettingsConnectionString.Credentials = builder.Configuration["ConnectionString:Credentials"];
AppsettingsConnectionString.Host = builder.Configuration["ConnectionString:Host"];
AppsettingsConnectionString.Database = builder.Configuration["ConnectionString:Database"];
AppsettingsConnectionString.Username = builder.Configuration["ConnectionString:Username"];
AppsettingsConnectionString.Password = builder.Configuration["ConnectionString:Password"];
#endregion

#region Dependecy Injection
builder.Services.AddScoped<IAccountServices, AccountServices>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
