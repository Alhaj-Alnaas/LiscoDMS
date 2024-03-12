using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.Core.Interfaces.Providers;
using ACS.Core.Interfaces.Services;
using ACS.Core.Interfaces.UnitOfWork;
using ACS.DataAccess;
using ACS.DataAccess.UintOfWork;
using ACS.Services;
using ACS.Web.Providers;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReflectionIT.Mvc.Paging;
using SearchInOldSystem.DatabaseEntity;
using SearchInOldSystem.Services;
using Serilog;
using System.Security.Claims;

namespace ACS.Web
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
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<DataContext>(options =>
            //   options.UseSqlite("Filename=myLocalDb.db;"));

            // add by Alnaas to connect to old system database
            services.AddDbContext<OldSysDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddHttpContextAccessor();
            services.AddTransient<IUserProvider, UserProvider>();            
            services.AddScoped<IContactServices<Contact>, ContactServices<Contact>>();
            services.AddScoped<ICategoryServices<Category>, CategoryServices<Category>>();
            services.AddScoped<IMessagesServices<Message>, MessagesServices<Message>>();
            services.AddScoped<IPackageServices<Package>, PackageServices<Package>>();
            services.AddScoped<IDocServices<Doc>, DocServices<Doc>>();
            services.AddScoped<IFeedbackServices<Feedback>, FeedbackServices<Feedback>>();
            services.AddScoped<IOrgnaizationServices<Organization>, OrgnaizationServices<Organization>>();

            services.AddScoped<IExtendedUserInfoServices<ExtendedUserInfo>, ExtendedUserInfoServices<ExtendedUserInfo>>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.AddTransient<IOldSystemMessages, OldSystemServices>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new[]{
                    "ACS.Core"
                    });
            });

            services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap4";
                options.PageParameterName = "pageindex";
            });

            services.AddTransient(provider => configuration.CreateMapper());

            services.AddIdentityCore<SubApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();

            services.AddDefaultIdentity<BaseUser>(
                options =>{
                    options.SignIn.RequireConfirmedAccount = true;
                    //options.SignIn.RequireConfirmedPhoneNumber = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                }).AddRoles<IdentityRole>().AddEntityFrameworkStores<DataContext>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddHttpClient();

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(@"D:\Logs\log.txt",
            //.WriteTo.File("Logs/log.txt",
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true)
            .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTQ2NzU0QDMxMzkyZTMzMmUzMEVreE1Wa3ozZVFrVkM5UFpvVndJWkdhSER0SXpLMEdiOVd1MHFmSG4xVTg9");
            
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDgyNzUyQDMxMzkyZTMyMmUzMGQyN3RSeE1ZcHg4YXl1bmlNWDlUNDJiWVd3YXlsQ2NweDJWTkxpU0RMdmc9;NDgyNzUzQDMxMzkyZTMyMmUzMG9JUE5kZXN0ZnFtVFF4cmxGSVAwbEZDWWdOWjlKNUpxK1ViWEN1N0dQejA9;NDgyNzU0QDMxMzkyZTMyMmUzMEVSZU85U1VoWFp2aE11cjZvSDdCOTZyWGlIVW5BeTNkd2tkeGdUMnZWbkk9");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseSignalR(config =>
            //{
            //    config.MapHub<NotificationHub>("/NotificationHub");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default", 
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
