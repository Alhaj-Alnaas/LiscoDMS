
using ACS.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SearchInOldSystem.DatabaseEntity;
using System;

using System.Windows.Forms;

namespace ACS.Archives
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense ("NTQ2NzU0QDMxMzkyZTMzMmUzMEVreE1Wa3ozZVFrVkM5UFpvVndJWkdhSER0SXpLMEdiOVd1MHFmSG4xVTg9");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@32302e312e30eJQAxLlY8myT3I7wL5vOKHGGQf2yFn6rhsNQegAd/js=");

            //("NjQ3MDE1QDMyMzAyZTMxMmUzMGN6UHBWSGNieEh4dWU2ekFLQjhGOFZyeEtwTTg2ME1BRUJ0K2FqN3UzOVE9");
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var services = new ServiceCollection();
            ConfiqureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                //var ArchiveMainScreen = serviceProvider.GetRequiredService<ArchiveMainScreen>();
                //Application.Run(ArchiveMainScreen);

                var logform = serviceProvider.GetRequiredService<Loginfrm>();
                Application.Run(logform);
            }
           
        }

        private static void ConfiqureServices(ServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>

            options.UseSqlServer("Server=10.10.102.16;Database=ACSdb;user id=sa;password=P@55w0rd;Trusted_Connection=false;MultipleActiveResultSets=true"));

            //options.UseSqlServer("Server=10.10.102.16;Database=ASCdb_beta;user id=sa;password=P@55w0rd;Trusted_Connection=false;MultipleActiveResultSets=true"));

            services.AddDbContext<OldSysDBContext>(options =>

            options.UseSqlServer("Server=10.10.102.16;Database=OldSysDB;user id=sa;password=P@55w0rd;Trusted_Connection=false;MultipleActiveResultSets=true"));

            //options.UseSqlServer("Server=10.10.102.16;Database=OldSysDB;user id=sa;password=P@55w0rd;Trusted_Connection=false;MultipleActiveResultSets=true"));

            //services.AddScoped<ArchiveMainScreen>();
            services.AddScoped<Loginfrm>();
        }
    }
}
