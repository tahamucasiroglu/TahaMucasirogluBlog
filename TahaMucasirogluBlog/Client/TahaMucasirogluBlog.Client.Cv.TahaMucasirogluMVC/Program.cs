using TahaMucasirogluBlog.Client.Cv.TahaMucasirogluMVC.Extensions;
using TahaMucasirogluBlog.Client.Cv.TahaMucasirogluMVC.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MaintenanceOption>(builder.Configuration.GetSection("Maintenance"));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.AddSingleton();
Serilog.ILogger logger = builder.AddLogger();

builder.Services.AddHttpClient();







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

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");


app.AddMiddlewares(); //middlewareleri en sona koydum. yoksa sayfa yönlendirmeleri gibi şeylerde sonraki kısımlar yüklenmez eksik çalışma olur


app.Run();