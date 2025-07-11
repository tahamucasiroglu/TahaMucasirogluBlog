using System.Threading.RateLimiting;
using TahaMucasirogluBlog.Domain.Extensions;
using TahaMucasirogluBlog.Presentation.API.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.AddRateLimiter();

        string CorsName = builder.Configuration.GetCORSNameAppSettings();
        string CorsURLsString = builder.Configuration.GetCorsURLsAppSettings();
        string[] CorsUrls = CorsURLsString.Split(" ");
        bool AnyCors = builder.Configuration.GetAnyCorsAppSettings();


        builder.Services.AddHttpContextAccessor();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        Serilog.ILogger logger = builder.AddLogger(true);


        logger.Information($"CorsName  =  {CorsName}");
        logger.Information($"CorsURLsString  =  {CorsURLsString}");
        logger.Information($"AnyCors  =  {AnyCors}");

        builder.AddScoped();
        builder.AddSingleton();
        builder.AddDatabases(logger);

        builder.Services.AddMapperMapProfile();
        builder.Services.AddFluentValidationValidators();

        if (AnyCors) { builder.SetAnyCors(CorsName); } else { builder.SetCors(CorsName, CorsUrls); }

        builder.SetIdentity();




        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();



        app.Run();
    }
}