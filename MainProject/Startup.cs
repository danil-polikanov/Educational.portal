using BL;
using Domain.Entity;
using Domain.IRepository;
using MainProject.BLL.Interfaces.IServices;
using MainProject.BLL.Services;
using MainProject.Core;
using MainProject.DAL.Repository;
using MainProject.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DbContext,EducationPortalDbContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IRepository<PassingCourse>, Repository<PassingCourse>>(); 
            services.AddScoped<IRepository<UserEntity>, Repository<UserEntity>>();
            services.AddScoped<IRepository<MaterialEntity>, Repository<MaterialEntity>>();
            services.AddScoped<IRepository<SkillEntity>, Repository<SkillEntity>>();
            services.AddScoped<IRepository<CourseEntity>, Repository<CourseEntity>>();
            services.AddScoped<IPassingCourseService, PassingCourseService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IUserService, UserService>();
      

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => 
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
