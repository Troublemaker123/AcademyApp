using AcademyApp.Business;
using AcademyApp.Business.Implementation;
using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Validators;
using AcademyApp.Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcademyApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
           
            services.AddDbContext<Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AcademyAppDB")));


            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IAcademyProgramService, AcademyProgramService>();
            services.AddTransient<IAttendanceService, AttendanceService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IProgramService, ProgramService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IStaffService, StaffService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IMentorService, MentorService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
