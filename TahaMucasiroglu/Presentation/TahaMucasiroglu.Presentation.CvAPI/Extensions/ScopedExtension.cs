using TahaMucasiroglu.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasiroglu.Infrastructure.CvRepository.Repository.Concrete;
using TahaMucasiroglu.Service.CvDatabase.Abstract;
using TahaMucasiroglu.Service.CvDatabase.Concrete;

namespace TahaMucasiroglu.Presentation.CvAPI.Extensions
{
    static public class ScopedExtension
    {
        public static void AddScoped(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICvService, CvService>();
            builder.Services.AddScoped<IExperienceDatabaseService, ExperienceDatabaseService>();
            builder.Services.AddScoped<IExperienceTechnologyDatabaseService, ExperienceTechnologyDatabaseService>();
            builder.Services.AddScoped<IExperienceTypeDatabaseService, ExperienceTypeDatabaseService>();
            builder.Services.AddScoped<IInfoDatabaseService, InfoDatabaseService>();
            builder.Services.AddScoped<ISkillDatabaseService, SkillDatabaseService>();
            builder.Services.AddScoped<ISubSkillDatabaseService,  SubSkillDatabaseService>();

            builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
            builder.Services.AddScoped<IExperienceTechnologyRepository, ExperienceTechnologyRepository>();
            builder.Services.AddScoped<IExperienceTypeRepository, ExperienceTypeRepository>();
            builder.Services.AddScoped<IInfoRepository, InfoRepository>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();
            builder.Services.AddScoped<ISubSkillRepository, SubSkillRepository>();


        }
    }
}
