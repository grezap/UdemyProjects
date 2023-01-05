using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaBasics
{
    public class ProducerService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly string _topic = "demo_dotnet";
        IProducer<string, string> _producer;
        private int _messageNumber = 1000;
        private string[] keys = { "user1", "user2", "user3", "user4", "user5", "user6", "user7", "user8", "user9" };
        private string[] values = { "item1", "item2", "item3", "item4", "item5", "item6", "item7", "item8", "item9" };
        private bool _cancelled = false;

        public ProducerService(ILogger<ProducerService> log)
        {
            _logger= log;
            BootstrapProducer();
        }

        private void BootstrapProducer() 
        {
            var config = new ProducerConfig();
            config.BootstrapServers = "localhost:9092";
            _producer = new ProducerBuilder<string,string>(config).Build();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {

            Console.CancelKeyPress += Console_CancelKeyPress;

            int messageLimit = 0;

            Random rnd = new Random();

            while (messageLimit <= _messageNumber && !_cancelled)
            {
                string key = keys[rnd.Next(keys.Length)];
                string value = values[rnd.Next(values.Length)];

                Message<string,string> message = new Message<string, string> { Key = key, Value = value };
                
                var dr = await _producer.ProduceAsync(_topic, message);

                if (dr.Status != PersistenceStatus.Persisted)
                {
                    _logger.LogError($"Failed to deliver message: {dr.Key} - {dr.Value}");
                }
                else
                {
                    _logger.LogInformation($"Produced event to topic {_topic}: key = {dr.Key} value = {dr.Value}");
                    
                }
                messageLimit++;
                Thread.Sleep(500);
            }

            _producer.Flush(TimeSpan.FromSeconds(10));

        }

        private void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            _cancelled = true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _producer?.Dispose();
            return Task.CompletedTask;
        }
    }
}
