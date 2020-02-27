using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenPipes;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MicroServiceWebApiV2
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
            services.AddControllers();

            //add mass transit to services
            services.AddMassTransit(cfg => {
                //Add Bus to the collection
                cfg.AddBus(ConfigureBus);

                //Add consumer to the collection
                cfg.AddConsumer<MessageConsumer>();
            });

            services.AddHostedService<BusService>();
        }

        private static IBusControl ConfigureBus(IServiceProvider arg)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg => {
                cfg.Host("localhost","/", h => { });
                //queue-1 : is the name of the queue
                cfg.ReceiveEndpoint("queue-1" , e => {
                    e.PrefetchCount = 16;
                    e.UseMessageRetry(x => x.Interval(2 ,100));
                    e.Consumer<MessageConsumer>();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
