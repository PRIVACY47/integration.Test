using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeChamp.Integrations.Scheduler.RabbitMQHouse.RabbitMQProducers.Interfaces
{
    internal interface IUpsertUsersI2TProducer
    {
        void UpsertUsersI2T(string data, string queueName);
    }
}
