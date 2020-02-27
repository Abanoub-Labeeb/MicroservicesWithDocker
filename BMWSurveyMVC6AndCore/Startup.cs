using BMWSurvey;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BMWSurveyMVC6AndCore
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
            services.AddControllersWithViews();

            //register DB Context
            services.AddDbContext<BMWApplicationContext>();
            //you can use next if you did not override the OnConfiguring() Method in the DB Context to define connection string
            //services.AddDbContext<BMWApplicationContext>(options => 
            //                                             options.UseSqlServer(Configuration.GetConnectionString("BMWSurveyConnection")));


            //Dependency Injection in mvc code
            //refer to : https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/hands-on-labs/aspnet-mvc-4-dependency-injection
            //also     : https://www.youtube.com/watch?v=5A2UxMGA58g

            //whenever any class reference  IUnitOfWorkServiceProvider in the constructor to be injected
            //this will return the same instance of AutoMappingServiceProvider to be injected and used
            //call AutoMappingServiceProvider >> GetInstanceUniqueID() from each injected instance and it will return the same number
            services.AddSingleton<IAutoMappingServiceProvider, AutoMappingServiceProvider>();

            //whenever any class reference  IUnitOfWorkServiceProvider in the constructor to be injected
            //this will return new instance of UnitOfWorkServiceProvider to be injected and used
            //return the same instance for all references in this current user request
            //and will be destroyed after the scope of request / means it's valid for the cusrrent request like BLC 
            services.AddScoped<IUnitOfWorkServiceProvider, UnitOfWorkServiceProvider>();

            //will return new instance per each injected reference 
            //if you put 3 refernces to IUnitOfWorkServiceProvider on the constructor 
            //the it will inject 3 differenet instances of UnitOfWorkServiceProvider
            //services.AddTransient<IUnitOfWorkServiceProvider, UnitOfWorkServiceProvider>();

            //use camel notation 
            services.AddControllers().AddNewtonsoftJson(setupAction => setupAction.UseCamelCasing(true));

            //to use routing middleware
            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-3.1
            //services.AddRouting();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //add endpoints to the controllers actions without specifying any routes
                endpoints.MapControllers();

                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                
            });
        }
    }
}
