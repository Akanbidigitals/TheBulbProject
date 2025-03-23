using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TheBulbProject.DataAccess.DataContext;
using TheBulbProject.Service.Interface;
using TheBulbProject.Service.Repository;

namespace TheBulbProject.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void AddExtension(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ThebulbConnection");
            var applicationAssembly = typeof(ServiceCollectionExtension).Assembly;

            services.AddDbContext<AppDBcontext>(r => r.UseSqlServer(connectionString));
            services.AddScoped<IFormRepository,FormRepository>();
            services.AddScoped<IFieldRepository,FieldRepository>();
            services.AddScoped<IFieldResponseRepository,FieldResponseRepository>();
            services.AddScoped<ISignUpRepository,SignUpRepository>();
            services.AddScoped<ILoginRepository,LoginRepository>();

            services.AddValidatorsFromAssembly(applicationAssembly).AddFluentValidationAutoValidation();

        }
    }
}
