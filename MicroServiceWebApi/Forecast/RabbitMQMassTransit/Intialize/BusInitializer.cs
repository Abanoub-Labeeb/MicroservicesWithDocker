using GreenPipes;
using MassTransit;
using MassTransit.BusConfigurators;
using MassTransit.RabbitMqTransport;
using System;

namespace MicroServiceWebAPI
{
  public class BusInitializer
  {
    public static IBusControl CreateBus(string host,string virtualHost, string queueName, Action<IRabbitMqBusFactoryConfigurator> moreInitialization)
    {
        var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host(new Uri(host+"/"+ virtualHost),host => {
                host.Username("guest");
                host.Password("guest");
            });

            cfg.ReceiveEndpoint(queueName, ep =>
            {
                ep.PrefetchCount = 16;
                ep.UseMessageRetry(r => r.Interval(2, 100));
            });
            moreInitialization(cfg);
        });
            
      return bus;
    }
  }
}
