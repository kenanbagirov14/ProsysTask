using Exam.Application.Interfaces.Repositories.Base;
using ExamPersistence.DBContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPersistence.Extentions
{
    public static class AddPersitenceConfigureService
    {
        public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ExamDBContext>(conf =>
            {
                string connectionString = configuration.GetConnectionString("examConnectionString");
                conf.UseSqlServer(connectionString, opt =>
                {
                    opt.EnableRetryOnFailure();
                });

            });

      //      string connectionString = configuration.GetConnectionString("examConnectionString");
      //      services.AddDbContext<ExamDBContext>(options =>
      //      options.UseSqlServer(connectionString)
      ////.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()))
      //);

            return services;
        }
    }
}
