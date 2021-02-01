using Confluent.Kafka;
using KafkaConsumer.Service;
using Serilog;
using System;

namespace KafkaConsumer
{
    public class KafkaConsumerService : IService
    {
        private ILogger _logger;
        private IConsumer<Ignore, string> _consumer;
        private string _topic;

        public KafkaConsumerService(ILogger logger, IConsumer<Ignore, string> consumer)
        {
            _logger = logger;
            _consumer = consumer;
        }

        public void Start()
        {
            Console.WriteLine("What topic to consume?");
            _topic = Console.ReadLine();

            _consumer.Subscribe(_topic);
            while (true)
            {
                try
                {
                    _logger.Information("Listening to Kafka message...");
                    var consumerResult = _consumer.Consume();
                    var messageData = consumerResult.Message.Value;
                    _logger.Information("Message data received: {0}", messageData);
                    _logger.Information("Total character received: {0}", messageData.Length);
                }
                catch(ConsumeException e)
                {
                    _logger.Error($"Consume error: { e.Error.Reason }");
                    _consumer.Close();
                }
                catch(OperationCanceledException e)
                {
                    _logger.Information($"Closing consumer: { e.Message }");
                    _consumer.Close();
                }
                _logger.Information("---------- Message Ended ----------");
            }
        }

        public void Stop()
        {
            // Dispose consumer instance to ensure that active sockets are closed, internal state is cleaned up.
            _consumer.Dispose();
        }
    }
}
