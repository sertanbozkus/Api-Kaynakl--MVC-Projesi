using BilgeCinema.MVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// appsetings.json kullan�m� i�in:

var settings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();

builder.Services.AddHttpClient(); // Client nesnesine api'ye json format�nda istek atmak i�in ihtiyac�m var

builder.Services.AddSingleton(settings);

// addSingleton -> Yukar�daki AppSettings class'�n� newlenip olu�turdu�u nesneden tek bir kopya olacak ve hep ayn� kopya (instance) kullan�lacak.

// addScoped -> Her istek yeni kopya.

// burada neden AddSingleton kullan�yoruz da AddScoped kullanm�yoruz?
// -> BELGE ALMAK ���N GEREKL� SORU - CEVAP!





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
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();
