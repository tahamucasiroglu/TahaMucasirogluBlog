using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Extensions;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Options;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MaintenanceOption>(builder.Configuration.GetSection("Maintenance"));

Serilog.ILogger logger = builder.AddLogger();
builder.AddNewtonsoftJson();
builder.AddSingleton();
builder.AddScoped();
builder.Services.AddRazorPages();

builder.NTNAddFluentValidation();

builder.Services.AddHttpClient();

builder.Services.AddMapperMapProfile();



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStatusCodePagesWithReExecute("/NotFound");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();

app.UseAuthentication();    // mutlaka buraya
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");


app.AddMiddlewares(); //middlewareleri en sona koydum. yoksa sayfa yönlendirmeleri gibi þeylerde sonraki kýsýmlar yüklenmez eksik çalýþma olur


app.Run();
