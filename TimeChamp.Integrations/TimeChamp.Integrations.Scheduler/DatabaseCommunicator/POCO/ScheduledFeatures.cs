using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using TimeChamp.Integrations.Scheduler.Converters;

namespace TimeChamp.Integrations.Scheduler.DatabaseCommunicator.POCO
{
    public class ScheduledFeatures
    {
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }
        public string IntegrationName { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId IntegrationId { get;set; }
        public string BaseUrl { get; set; } = string.Empty;
        public BsonDocument AuthKeys { get; set; }
        public BsonDocument ScheduledTime { get; set; }
        public string FeatureName { get; set; } = string.Empty;
        public string EndPoint { get; set; } = string.Empty;
        public string HttpMethod { get; set; } = string.Empty;
        public string TimeChampEndPoint { get; set; } = string.Empty;
        public string TimeChampHttpMethod { get; set; } = string.Empty;
        public bool DataToTimeChamp { get; set; } = false;
        public List<string> JobIds { get; set; }
        public List<string> NewJobIds { get; set; }
    }
}
