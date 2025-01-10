
using MongoDB.Bson;

namespace TimeChamp.Integrations.Scheduler.DatabaseCommunicator.DatabaseModels
{
    public class HelloUser
    {
        public ObjectId Id { get; set; }
        public string name { get; set; }
        public string age { get; set; }
    }
}
