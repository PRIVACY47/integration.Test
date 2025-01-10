using System.Text.Json;

namespace TimeChamp.Integraions.MainEngine.Models
{
    public class ScheduledFeaturesDeserialization
    {


        public string Id { get; set; }
        public string IntegrationName { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
        public string IntegrationId { get; set; }
        public string BaseUrl { get; set; } = string.Empty;
        public string AuthKeys { get; set; }
        public string ScheduledTime { get; set; }
        public string FeatureName { get; set; } = string.Empty;
        public string EndPoint { get; set; } = string.Empty;
        public string HttpMethod { get; set; } = string.Empty;
        public string TimeChampEndPoint { get; set; } = string.Empty;
        public string TimeChampHttpMethod { get; set; } = string.Empty;
        public bool DataToTimeChamp { get; set; } = false;
    }
}
