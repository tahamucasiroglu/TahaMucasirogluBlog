using TahaMucasiroglu.Domain.Extensions;
using TahaMucasiroglu.Infrastructure.P2PMessageRepository.Context;
using TahaMucasiroglu.Presentation.API.Extensions;
using TahaMucasiroglu.Presentation.P2PMessageAPI.Extensions;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.AddRateLimiter();


        builder.Services.AddHttpContextAccessor();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        Serilog.ILogger logger = builder.AddSeriLoggerToService(builder.Configuration.GetLogLevelAppSettings(), true, "Logs/ApiLog-.txt");

        builder.AddScoped();
        builder.AddSingleton();
        builder.AddDatabase<P2PMessageTahaMucasirogluContext>(
            logLevel: builder.Configuration.GetDatabaseSettingsDatabaseLogLevelAppSettings(),
            enableSensitiveDataLogging: builder.Configuration.GetDatabaseSettingsEnableSensitiveDataLoggingAppSettings(),
            enableDetailedErrors: builder.Configuration.GetDatabaseSettingsEnableDetailedErrorsAppSettings(),
            SqlServerConnectionStrings: builder.Configuration.GetConnectionString("SqlServerConnectionStrings") ?? throw new Exception("Connection string cv projesinde bulunamadý."),
            logger);

        builder.Services.AddMapperMapProfile();
        builder.Services.AddFluentValidationValidators();

        builder.SetCors(logger, " ");

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