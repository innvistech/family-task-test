using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.AutoMapper;

namespace WebApi
{
    public static class Setup
    {
        public static void AddSupportingServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(MemberProfile).Assembly);
            services.AddAutoMapper(typeof(TaskProfile).Assembly);

            services.AddMvc().AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddDbContext<DataLayer.FamilyTaskContext>(options =>
            {
                options.UseSqlServer(configuration.GetSection("ConnectionStrings:SqlDb").Value);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader());
            });
        }
    }
}
