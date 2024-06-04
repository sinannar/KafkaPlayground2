using Confluent.Kafka;

Console.Clear();
Console.WriteLine("Hello, from Producer");

const string topic = "messageTopic";

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092",
};
using var producer = new ProducerBuilder<string, string>(config).Build();

string key, message;
while (true)
{
    Console.WriteLine("Key:"); 
    key = Console.ReadLine();
    Console.WriteLine("Message:"); 
    message = Console.ReadLine();

    var result = await producer.ProduceAsync(topic, new Message<string, string> { Key = key!, Value = message! });
    Console.WriteLine($"({key}:{message}) sent {result.Status}");
    Task.Delay(1000).Wait();
}
