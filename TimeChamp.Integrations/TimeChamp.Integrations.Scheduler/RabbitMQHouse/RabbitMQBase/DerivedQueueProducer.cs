using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeChamp.Integrations.Scheduler.RabbitMQHouse.RabbitMQBase
{
    internal class DerivedQueueProducer : BaseQueueProducer<string>
    {
        public DerivedQueueProducer(string queueName) : base(queueName)
        {
        }

        public void SendDataToQueue(string message)
        {
            SendMessage(message);
        }
    }
}
