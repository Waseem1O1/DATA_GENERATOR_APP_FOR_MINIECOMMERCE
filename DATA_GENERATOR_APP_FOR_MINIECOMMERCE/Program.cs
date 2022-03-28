using DATA_GENERATOR_APP_FOR_MINIECOMMERCE.Models;
using DATA_GENERATOR_APP_FOR_MINIECOMMERCE.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient(typeof(IDataGenerator<>), typeof(DataGeneratorService<>));

var connectionString = builder.Configuration.GetConnectionString("AuthenticationDbContextContextConnection");
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 28))));
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
    pattern: "{controller=DataGenerator}/{action=GenerateData}/{id?}");

app.Run();
