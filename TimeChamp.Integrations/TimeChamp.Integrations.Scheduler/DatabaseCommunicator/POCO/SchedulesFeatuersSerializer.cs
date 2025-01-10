using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeChamp.Integrations.Scheduler.Converters;

namespace TimeChamp.Integrations.Scheduler.DatabaseCommunicator.POCO
{
    public class SchedulesFeatuersSerializer
    {

        public ObjectId Id { get; set; }
        public string IntegrationName { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;

        public ObjectId IntegrationId { get; set; }
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
