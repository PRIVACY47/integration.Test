using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace TimeChamp.Integrations.Scheduler.RabbitMQHouse.RabbitMQBase
{
    public abstract class BaseQueueConsumer<T>
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        protected BaseQueueConsumer(string queueName)
        {
            string hostName = "localhost";
            var factory = new ConnectionFactory() { HostName = hostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            QueueName = queueName;
        }

        protected string QueueName { get; }

        protected void ConsumeMessages(Action<T> messageHandler)
        {
            _channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(body));
                Console.WriteLine($" [x] Received '{message}' from queue '{QueueName}'");

                // Call the provided message handler
                messageHandler?.Invoke(message);
            };

            _channel.BasicConsume(queue: QueueName, autoAck: true, consumer: consumer);
        }

        public void CloseConnection()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
