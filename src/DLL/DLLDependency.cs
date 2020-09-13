using DLL.DBContext;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLL
{
    public class DLLDependency
    {
        public static void AllDependency(IServiceCollection services, IConfiguration Configuration)
        {    
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            //repository dependency

            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        }
    }
}