using AcademyApp.Api.Utility;
using AcademyApp.Business;
using AcademyApp.Business.Helpers;
using AcademyApp.Business.Implementation;
using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Validators;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.ViewModels;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using DinkToPdf;
using DinkToPdf.Contracts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text;

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

            // PDF print
           /* var context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll"));*/

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            // register Validators - inherited AbstractValidator<>
            services.AddScoped<IValidator<UserViewModel>, UserViewValidators>();
            services.AddScoped<IValidator<AcademyProgramViewModel>, AcademyProgramValidators>();
            services.AddScoped<IValidator<GroupMembersViewModel>, GroupMemberValidators>();
            services.AddScoped<IValidator<GroupViewModel>, GroupValidators>();
            services.AddScoped<IValidator<MentorViewModel>, MentorValidators>();
            services.AddScoped<IValidator<StudentViewModel>, StudentValidators>();
            services.AddScoped<IValidator<SubjectViewModel>, SubjectValidators>();
            services.AddScoped<IValidator<UserLoginViewModel>, UserLoginValidators>();

            services.AddControllers();

            // Fluent Validation
            services.AddMvc(options => {
                options.Filters.Add(typeof(ValidateModelAttribute));
            }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            IdentityModelEventSource.ShowPII = true; //To show detail of error and see the problem

            // configure CallBack Urls
            var callBacksObj = Configuration.GetSection("CallBackUrls");
            services.Configure<CallBackUrls>(callBacksObj);
            var callBacks = callBacksObj.Get<CallBackUrls>();


            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // DB
            services.AddDbContext<Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AcademyAppDB")));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            // Interfaces & Implementations
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IAcademyProgramService, AcademyProgramService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IMentorService, MentorService>();
            services.AddTransient<IGroupMemberService, GroupMemberService>();
            services.AddTransient<IAcademyService, AcademyService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISubCategoryService, SubCategoryService>();
            services.AddTransient<IRatingService, RatingService>();
            services.AddTransient<INonWorkingDayService, NonWorkingDayService>();
            services.AddTransient<IClassRoomService, ClassRoomService>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IMailService, MailService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            dbContext.SeedData();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors("MyPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
