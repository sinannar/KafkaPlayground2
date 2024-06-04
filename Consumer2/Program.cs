using Confluent.Kafka;

Console.Clear();
Console.WriteLine("Hello, from Consumer 2");

const string topic = "messageTopic";

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "cg_1",
    AutoOffsetReset = AutoOffsetReset.Earliest
};
using var consumer = new ConsumerBuilder<string, string>(config).Build();
consumer.Subscribe(topic);


while (true)
{
    var consumeResult = consumer.Consume();
    Console.WriteLine(consumeResult.Message.Value);
    Console.WriteLine($"({consumeResult.Message.Key}:{consumeResult.Message.Value}) receieved");

    consumer.Commit(consumeResult);
}
