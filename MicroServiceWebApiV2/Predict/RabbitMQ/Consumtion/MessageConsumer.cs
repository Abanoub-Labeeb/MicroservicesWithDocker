using MassTransit;
using MicroServiceWebApiV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceWebApiV2
{
    public class MessageConsumer : IConsumer<Message>
    {
        public Task Consume(ConsumeContext<Message> context)
        {
            Message msg = context.Message;
            return Task.CompletedTask;
        }
    }
}
