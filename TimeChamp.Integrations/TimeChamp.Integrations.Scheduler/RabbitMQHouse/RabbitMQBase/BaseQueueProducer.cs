using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
namespace TimeChamp.Integrations.Scheduler.RabbitMQHouse.RabbitMQBase
{
    public class BaseQueueProducer<T> : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        protected string QueueName { get; }

        protected BaseQueueProducer(string queueName)
        {
            string hostName = "localhost";
            var factory = new ConnectionFactory() { HostName = hostName, UserName = "guest", Password ="guest"};
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            QueueName = queueName;
        }

        protected void SendMessage(T message)
        {
            _channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            _channel.BasicPublish(exchange: "", routingKey: QueueName, basicProperties: null, body: body);
            Console.WriteLine($" [x] Sent '{message}' to queue '{QueueName}'");
        }

        public void CloseConnection()
        {
            _channel?.Close();
            _connection?.Close();
        }

        public void Dispose()
        {
            CloseConnection();
            GC.SuppressFinalize(this);
        }

        ~BaseQueueProducer()
        {
            CloseConnection();
        }
    }
}
