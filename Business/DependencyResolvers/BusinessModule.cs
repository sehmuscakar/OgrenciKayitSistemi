using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers
{
    public static class BusinessModule
    {
        public static void MyconfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<IStudentDal, StudentDal>();

            services.AddScoped<ITeacherService, TeacherManager>();
            services.AddScoped<ITeacherDal, TeacherDal>();
            // Diğer bağımlılıkları burada ekleyin...
        }
    }
}
