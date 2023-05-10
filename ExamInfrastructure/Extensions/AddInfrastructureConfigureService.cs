using Exam.Application.Interfaces.Repositories.Base;
using ExamInfrastructure.Repositories;

using ExamPersistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamInfrastructure.Extensions
{
    public static class AddInfrastructureConfigureService
    {
        public static IServiceCollection AddInfrastructurService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IClassRoomRepository, ClassRoomRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IClassRoomService, ClassRoomService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();

            return services;
        }
    }
}
