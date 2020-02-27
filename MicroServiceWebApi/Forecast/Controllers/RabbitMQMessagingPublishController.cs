using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceWebAPI.WeatherForecast.Forecast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQMessagingPublishController : ControllerBase
    {   
        private MessageProducer _messageProducer;
        public RabbitMQMessagingPublishController(MessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        // GET: api/RabbitMQMessaging
        [HttpGet]
        public void Get()
        {
            Message message = new Message() { Subject = "test-subject" , Body = "test-body"};
            _messageProducer.PublishMessageEvent(message);
        }

        // GET: api/RabbitMQMessaging/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RabbitMQMessaging
        [HttpPost]
        public void Post([FromBody] Message message)
        {
        }

        
    }
}
