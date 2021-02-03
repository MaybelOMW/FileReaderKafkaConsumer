# FileReaderKafkaConsumer

Kafka Consumer Console Application example that subscribes to a created topic using Confluent Kafka to consume message/data string published. Serilog is used to log significant consumer action into file and console. 

## Demo

To be added soon.

## Installation
1. Setup Docker Compose to pull Kafka and Zookeeper images. Create a Kafka Topic using Docker CLI and Kafka Shell Script. (Link will be added soon.)

2. Setup Kafka Producer to publish message/data string. Checkout [FileReaderKafkaProducer](https://github.com/MaybelOMW/FileReaderKafkaProducer) !

3. Download the code in this repository.

## Framework and Packages Detail
**Framework: netcoreapp3.1** 

**NuGets:**
| Name                                      | Version       | Functionality                                                                                    |
| ----------------------------------------- |:-------------:| :------------------------------------------------------------------------------------------------|
| Autofac                                   | 6.1.0         | Dependency injection into IoC container, manage dependencies between classes.                    |
| Confluent.Kafka                           | 1.5.3         | Kafka .NET Client that provides high-level Producer and Consumer Classes and Interfaces.         |
| Serilog                                   | 2.10.0        | Provides diagnostic logging to files and console.                                                |
| Serilog.Sinks.Console                     | 3.1.1         | Writes log events to the Windows Console, supports coloring and themes.                          |
| Serilog.Sinks.File                        | 4.1.0         | Writes log events to 1 or more text files.                                                       |

## Usage
Using Visual Studio,
1. Build -> Clean Solution (This will delete all the build output files)
2. Build -> Rebuild Solution Rebuilds everything. (Try Build Solution if rebuild option unavailable)
3. Run code in Visual Studio with or without the debugger is fine.
4. Input the Kafka Topic created when the console application prompt.

## Expected Outcome
- Data string will be consumed automatically.
- Consumed string and producer action log will be added into bin/debug/Logs/ConsumerLog.txt.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## Reference link / Resources
[Autofac](https://github.com/autofac/Autofac#get-started)

[Confluent.Kafka](https://docs.confluent.io/clients-confluent-kafka-dotnet/current/index.html)

[Serilog](https://serilog.net/)

[Serilog.Sinks.Console](https://github.com/serilog/serilog-sinks-console#getting-started)

[Serilog.Sinks.File](https://github.com/serilog/serilog-sinks-file#getting-started)
