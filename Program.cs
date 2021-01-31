using Autofac;
using Confluent.Kafka;
using KafkaConsumer.Service;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Net;

namespace KafkaConsumer
{
    class Program
    {
        private static IContainer _container;

        static Program()
        {
            var logger = new LoggerConfiguration().MinimumLevel.Debug()
                                                  .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                                                  .WriteTo.File("Logs\\ConsumerLog.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: null)
                                                  .CreateLogger();

            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                // The GroupId property is mandatory and specifies which consumer group the consumer is a member of.
                GroupId = "foo", 
                //  The AutoOffsetReset property specifies what offset the consumer should start reading from in the event there are no committed offsets for a partition, 
                //  or the committed offset is invalid (perhaps due to log truncation).
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

            var builder = new ContainerBuilder();
            builder.RegisterInstance(logger).As<ILogger>().SingleInstance();
            builder.RegisterInstance(consumer).As<IConsumer<Null, string>>().SingleInstance();
            builder.RegisterType<KafkaConsumerService>().As<IService>().SingleInstance();
            _container = builder.Build();
        }
        static void Main(string[] args)
        {
            var service = _container.Resolve<IService>();
            service.Start();
            service.Stop();
            Console.ReadLine();
        }
    }
}
