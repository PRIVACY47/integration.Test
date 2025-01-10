using TimeChamp.Integrations.Scheduler.RabbitMQHouse.RabbitMQBase;

namespace TimeChamp.Integrations.Scheduler.RabbitMQHouse.RabbitMQProducers
{
    public class UpsertUsersI2TProducer
    {
        
        public UpsertUsersI2TProducer()
        {
        }

        public void UpsertUsersI2T(string  data,string queueName)
        {
            using (var producer = new DerivedQueueProducer(queueName))
            {
                producer.SendDataToQueue(data);
            }
        }
    }
}
