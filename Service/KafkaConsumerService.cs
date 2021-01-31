using Confluent.Kafka;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer
{
    public class KafkaConsumerService
    {
        private ILogger _logger;
        private IConsumer<Null, string> _consumer;
        private string _topic;

        public KafkaConsumerService(ILogger logger, IConsumer<Null, string> consumer)
        {
            _logger = logger;
            _consumer = consumer;
        }

        public static async Task Start()
        {
            
        }

        public void Stop()
        {
            
        }
    }
}
