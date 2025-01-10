using Newtonsoft.Json;
using TimeChamp.Integraions.MainEngine.AdaptarServiceRouter;
using TimeChamp.Integraions.MainEngine.Models;
using TimeChamp.Integraions.MainEngine.RabbitMQHouse.RabbitMQBase;

namespace TimeChamp.Integraions.MainEngine.RabbitMQHouse.RabbitMQConsumer
{
    public class UpsertUsersI2TConsumer : BaseQueueConsumer<string>
    {
        public AdaptarService _adaptarService;
        public UpsertUsersI2TConsumer(AdaptarService adaptarService) : base("677cada267ec8bcd9b5b195cGetTime")
        {
            _adaptarService = adaptarService;
        }
        public void StartListening()
        {
            ConsumeMessages(UpsertUsersI2T);
        }

        public async void UpsertUsersI2T(string data)
        {
            ScheduledFeaturesDeserialization scheduledFeaturesDeserialization = JsonConvert.DeserializeObject<ScheduledFeaturesDeserialization>(data);
           string response =  await _adaptarService.MakeApiCall(scheduledFeaturesDeserialization);

            var x = response;
            
        }
    }
}
