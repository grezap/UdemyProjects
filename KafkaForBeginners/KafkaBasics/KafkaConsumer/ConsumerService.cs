﻿
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using KafkaConsumer.Model;
using KafkaConsumer.Model.TestMySql;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NJsonSchema.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer
{
    public class ConsumerService : IHostedService
    {
        private readonly ILogger<ConsumerService> _logger;
        private readonly string _topic = "testgzav5.test_gza.test_table";
        private IConsumer<string, string> _consumer;
        private bool _cancelled = false;
        private CachedSchemaRegistryClient _schemaRegistry;
        CancellationTokenSource _cancelToken;

        public ConsumerService(ILogger<ConsumerService> logger)
        {
            _logger = logger;
            BootstrapConsumer();
        }

        private void BootstrapConsumer()
        {
            var schemaRegistryConfig = new SchemaRegistryConfig();
            schemaRegistryConfig.Url= "http://schemaregistry:8081";

            var config = new ConsumerConfig();
            config.BootstrapServers = "brokerone:9092,brokertwo:9092,brokerthree:9092";
            config.GroupId = "demo-dotnet-consumer-mysql-group1";
            config.AutoOffsetReset = AutoOffsetReset.Earliest;
            config.EnableAutoOffsetStore = false;
            config.EnableAutoCommit = false;
            config.PartitionAssignmentStrategy = PartitionAssignmentStrategy.CooperativeSticky;
            config.StatisticsIntervalMs = 5000;
            config.SessionTimeoutMs = 6000;
            
            _schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
            _consumer = new ConsumerBuilder<string, string>(config)
                //.SetKeyDeserializer(Deserializers.Utf8)
                //.SetValueDeserializer(JsonConvert.DeserializeObject<TestMySqlJson>())
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

            _cancelToken = new CancellationTokenSource();
            int counter = 0;
            try
            {
                while (!_cancelled)
                {
                    var cr = _consumer.Consume(_cancelToken.Token);
                    var testModel = cr?.Message?.Value;

                    //var after = JsonConvert.DeserializeObject<Model.TestMySql.TestMySqlJson>(testModel);

                    _consumer.Assign(cr.TopicPartition);

                    if (counter == 5)
                    {
                        _consumer.Unassign();
                    }
                    else
                    {
                        //_consumer.Commit();
                        counter++;
                    }

                    _logger.LogInformation($"Consumed event from topic {_topic} with key {cr.Message.Key,-10} and value {cr.Message.Value}");
                    //_logger.LogInformation($"Serialized: {JsonConvert.SerializeObject(after)}");
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
            _cancelToken?.Cancel();
            e.Cancel = true;
            _cancelled = true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
