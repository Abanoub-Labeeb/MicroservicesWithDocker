using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MicroServiceWebAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MicroServiceWebApi
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

            /**
             *Add mass transit to inject the mass transit classes we are going to use to handle 
             * the messaging with the rabbiymq
             * Install-Package MassTransit.Extensions.DependencyInjection -Version 6.1.0
             * Install-Package MassTransit.RabbitMQ -Version 6.1.0
             * 
            **/
            services.AddHealthChecks();
            services.AddMassTransit();

            //Whenever reference  IBusControl an instance will be injected
            // when you specify the queue name , when the message arrive to the exchange the binding will know to which queue it will be sent
            //rabbitmq://a-machine-name/a-virtual-host
            services.AddSingleton(provider => BusInitializer.CreateBus("rabbitmq://localhost", "", "MassTransitPubSubExample_queue_1", cfg => { /**nothing to be added to the configuration in here**/ }));

            //IBusControl :  IBus, IPublishEndpoint, IPublishObserverConnector, IPublishEndpointProvider, ISendEndpointProvider, ISendObserverConnector, IConsumePipeConnector, IRequestPipeConnector, IConsumeMessageObserverConnector, IConsumeObserverConnector, IReceiveObserverConnector, IReceiveEndpointObserverConnector, IReceiveConnector, IEndpointConfigurationObserverConnector, IProbeSite
            //IBus        :  is a logical endpoint contains (1 local endpoint - 0+ recieve endpoints)
            //IPublishEndpoint : let's the underlying transport know exactly which is the actual endpoint the message will be send to , (RabbitMQ , Azure Service Bus)
            //Whenever reference  IBus,IPublishEndpoint the same instance of IBusControl will be injected
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());

            //BusService : if bus control will be managed by the us then we will use BusService to Start/Stop the bus 
            //when un comment the app will keep loading without result
            //services.AddSingleton<IHostedService, BusService>();

            //whenever ref. the class inject an instance
            services.AddSingleton<MessageProducer, MessageProducer>();
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

            /**
             *install-package Microsoft.AspNetCore.Diagnostics 
             *install-package Microsoft.AspNetCore.Diagnostics.HealthChecks
            **/
            app.UseHealthChecks("/health", new HealthCheckOptions { Predicate = check => check.Tags.Contains("ready") });
        }
    }
}
