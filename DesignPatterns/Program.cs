using DesignPatterns.Context;
using DesignPatterns.DesignPatterns.Decorator;
using DesignPatterns.DesignPatterns.Observer;
using DesignPatterns.DesignPatterns.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// 1. Observer Sistemini Hazýrla
var observerObject = new ObserverObject();

// Gözlemcileri (Observer'larý) Kayýt Et
observerObject.RegisterObserver(new WelcomeMessageObserver());
observerObject.RegisterObserver(new DiscountObserver()); // Ýndirim haberi için ekledik

// 2. ObserverObject'i sisteme Singleton olarak ekle (Hata bu satýr eksik olduðu için geliyordu)
builder.Services.AddSingleton(observerObject);

// Add services to the container.
builder.Services.AddSession();
builder.Services.AddControllersWithViews();

// Scoped Servisler
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<BankContext>();
builder.Services.AddScoped<IProductService, SqlProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();