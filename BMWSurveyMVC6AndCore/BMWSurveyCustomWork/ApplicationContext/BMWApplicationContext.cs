using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BMWSurvey
{
    public class BMWApplicationContext : DbContext
    {
        /**
         * for migrations refer to : 
         * https://docs.microsoft.com/en-us/aspnet/core/migration/22-to-30?view=aspnetcore-2.1&tabs=visual-studio#mvc-service-registration
         * https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-core-3-0-preview-4/
         * https://stackoverflow.com/questions/57684093/using-usemvc-to-configure-mvc-is-not-supported-while-using-endpoint-routing
         * https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/search?view=aspnetcore-3.1
         * Please install next using nuget
         * PM> install-package EntityFramework
         * PM> install-package Microsoft.EntityFrameworkCore
         * PM> install-package Microsoft.EntityFrameworkCore.SqlServer
         * 
         * db context should be registered in Startup.cs >> ConfigureServices 
         
         **/

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //UseSqlServer is an extension method in Microsoft.EntityFrameworkCore.SqlServer
            optionsBuilder.UseSqlServer("data source=localhost;initial catalog=BMWSurvey;persist security info=True; Integrated Security=SSPI;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SurveyConfiguration());
        }
    }
}
