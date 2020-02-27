using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceWebAPI
{
    //https://masstransit-project.com/usage/configuration.html#asp-net-core
    public class MessageProducer
    {
        private IBusControl _busControl;
        public  MessageProducer(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public  async void PublishMessageEvent(Message message)
        {
            
            try
            {
                // Important! The bus must be started before using it!
                await _busControl.StartAsync();
                await _busControl.Publish<Message>(message);
            }
            finally
            {
                await _busControl.StopAsync();
            }
        }

        public async void SendMessageCommand(Message message)
        {
            try
            {
                // Important! The bus must be started before using it!
                await _busControl.StartAsync();
                await _busControl.Send<Message>(message);
            }
            finally
            {
                await _busControl.StopAsync();
            }
        }
    }
}
