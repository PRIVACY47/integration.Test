using MongoDB.Bson;
using MongoDB.Driver;
using TimeChamp.Integrations.Scheduler.DatabaseCommunicator.PipeLines;
using TimeChamp.Integrations.Scheduler.DatabaseCommunicator.DatabaseModels;
using TimeChamp.Integrations.Scheduler.DatabaseCommunicator.POCO;
using System.ComponentModel;

namespace TimeChamp.Integrations.Scheduler.DatabaseCommunicator
{
    public class MongoDbQuerryEngine : MongoDBConnector
    {
        public MongoDbQuerryEngine(IConfiguration configuration) : base(configuration)
        {
        }
        
        public async Task<List<ScheduledFeatures>> GetAllScheduledFeatures()
        {
            List<ScheduledFeatures> result = new List<ScheduledFeatures>();
            IMongoCollection<BsonDocument> subscribedIntegrationFeaturesCollection = _database.GetCollection<BsonDocument>("SubscribedIntegrationFeatures");
            if(subscribedIntegrationFeaturesCollection != null)
            {
                BsonDocument[] scheduledFeatures =  AggregationPipeLines.ScheduledFeatures;
                 result = await subscribedIntegrationFeaturesCollection.Aggregate<ScheduledFeatures>(scheduledFeatures).ToListAsync().ConfigureAwait(false);
            }
            return result;
        }
        public bool UpdateScheduleTimeForADocument(string documentId,BsonDocument? newScheduleTime,bool IsArchived)
        {
            var collection = _database.GetCollection<BsonDocument>("SubscribedIntegrationFeatures");
       
            var objectId = new ObjectId(documentId);

            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);

            var update = Builders<BsonDocument>.Update.Set("ScheduledTime", newScheduleTime);
            if(IsArchived)
            {
              var inactivateDocument  = Builders<BsonDocument>.Update.Set("InactiveDateTime", DateTime.UtcNow);
              collection.UpdateOne(filter, inactivateDocument);
            }

            var result = collection.UpdateOne(filter, update);

            return result.ModifiedCount > 0;
        }

        public bool UpdateJobIdsForADocument(ObjectId objectId, List<string> newScheduleTime)
        {
            var collection = _database.GetCollection<BsonDocument>("SubscribedIntegrationFeatures");

    

            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);

            var update = Builders<BsonDocument>.Update.Set("JobIds", newScheduleTime);

            var result = collection.UpdateOne(filter, update);

            return result.ModifiedCount > 0;
        }

        public async Task<ScheduledFeatures> GetAScheduledFeature(string objectId)
        {
           ScheduledFeatures result;
            IMongoCollection<BsonDocument> subscribedIntegrationFeaturesCollection = _database.GetCollection<BsonDocument>("SubscribedIntegrationFeatures");
            if (subscribedIntegrationFeaturesCollection != null)
            {
                BsonDocument[] scheduledFeatures = AggregationPipeLines.GetAScheduledFeature(new ObjectId(objectId));
                result = await subscribedIntegrationFeaturesCollection.Aggregate<ScheduledFeatures>(scheduledFeatures).FirstOrDefaultAsync().ConfigureAwait(false);
                return result;
            }
            return null;
        }
    }
}
