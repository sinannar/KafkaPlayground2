using Confluent.Kafka;
using Confluent.Kafka.Admin;


var config = new AdminClientConfig
{
    BootstrapServers = "localhost:9092",
};
using var admin = new AdminClientBuilder(config).Build();

const string topic = "messageTopic";
var topicSpesification = new TopicSpecification
{
    Name = topic,
    NumPartitions = 3,
    ReplicationFactor = 1,
};

try
{
    await admin.CreateTopicsAsync(new[] { topicSpesification }).ConfigureAwait(false);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

