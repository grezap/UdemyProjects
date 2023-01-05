using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace KafkaBasics
{
    public class ConsumerService : IHostedService
    {
        private readonly ILogger<ConsumerService> _logger;
        private readonly string _topic = "demo_dotnet";
        private IConsumer<string,string> _consumer;
        private bool _cancelled = false;

        public ConsumerService(ILogger<ConsumerService> logger)
        {
            _logger = logger;
            BootstrapConsumer();
        }

        private void BootstrapConsumer()
        {
            var config = new ConsumerConfig();
            config.BootstrapServers = "localhost:9092";
            config.GroupId = "demo-dotnet-consumer-group";
            config.AutoOffsetReset = AutoOffsetReset.Earliest;
            config.PartitionAssignmentStrategy = PartitionAssignmentStrategy.CooperativeSticky;
            config.StatisticsIntervalMs= 5000;
            config.SessionTimeoutMs = 6000;
            
            _consumer = new ConsumerBuilder<string, string>(config)
                .SetErrorHandler((_, e) => _logger.LogError($"Error: {e.Reason}"))
                //.SetStatisticsHandler((_,json) => { _logger.LogInformation($"Statistics: {json}"); })
                //.SetPartitionsAssignedHandler((c, partitions) => 
                //{
                //    _logger.LogInformation("Partitions incrementally assigned: [" +
                //        string.Join(',', partitions.Select(p => p.Partition.Value)) +
                //        "], all: [" +
                //        string.Join(',', c.Assignment.Concat(partitions).Select(p => p.Partition.Value)) +
                //        "]");
                //})
                //.SetPartitionsRevokedHandler((c, partitions) =>
                //{
                //    var remaining = c.Assignment.Where(atp => partitions.Where(rtp => rtp.TopicPartition == atp).Count() == 0);
                //    _logger.LogInformation(
                //        "Partitions incrementally revoked: [" +
                //        string.Join(',', partitions.Select(p => p.Partition.Value)) +
                //        "], remaining: [" +
                //        string.Join(',', remaining.Select(p => p.Partition.Value)) +
                //        "]");
                //})
                //.SetPartitionsLostHandler((c, partitions) =>
                //{
                //    _logger.LogInformation($"Partitions were lost: [{string.Join(", ", partitions)}]");
                //})
                .Build();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.CancelKeyPress += Console_CancelKeyPress;

            _consumer.Subscribe(_topic);

            var cancelToken = new CancellationTokenSource();

            try
            {
                while (!_cancelled)
                {
                    var cr = _consumer.Consume(cancelToken.Token);
                    _logger.LogInformation($"Consumed event from topic {_topic} with key {cr.Message.Key,-10} and value {cr.Message.Value}");
                }
            }
            catch (OperationCanceledException)
            {
                _consumer.Close();
                throw;
            }

            _consumer?.Close();

            return Task.CompletedTask;
        }

        private void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            _cancelled= true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
