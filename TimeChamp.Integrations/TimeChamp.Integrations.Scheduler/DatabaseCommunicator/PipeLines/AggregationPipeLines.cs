using MongoDB.Bson;

namespace TimeChamp.Integrations.Scheduler.DatabaseCommunicator.PipeLines
{
    public static class AggregationPipeLines
    {
        public static readonly BsonDocument[] ScheduledFeatures = new[]
{
    // Step 1: Join SubscribedIntegrationFeatures with IntegrationFeatures
    new BsonDocument("$lookup", new BsonDocument
    {
        { "from", "IntegrationFeatures" },
        { "localField", "IntegrationFeatureId" },
        { "foreignField", "_id" },
        { "as", "featureDetails" }
    }),
    // Step 2: Unwind the featureDetails array
    new BsonDocument("$unwind", "$featureDetails"),
    
    // Step 3: Join SubscribedIntegrationFeatures with CompanySubscribedIntegrations
    new BsonDocument("$lookup", new BsonDocument
    {
        { "from", "CompanySubscribedIntegrations" },
        { "localField", "SubscribedIntegrationId" },
        { "foreignField", "_id" },
        { "as", "companyIntegrationDetails" }
    }),
    // Step 4: Unwind the companyIntegrationDetails array
    new BsonDocument("$unwind", "$companyIntegrationDetails"),

    // Step 5: Join CompanySubscribedIntegrations with Integrations
    new BsonDocument("$lookup", new BsonDocument
    {
        { "from", "Integrations" },
        { "localField", "companyIntegrationDetails.IntegrationId" },
        { "foreignField", "_id" },
        { "as", "integrationDetails" }
    }),
    // Step 6: Unwind the integrationDetails array
    new BsonDocument("$unwind", "$integrationDetails"),

    // Step 7: Project the final fields for FeatureScheduler
    new BsonDocument("$project", new BsonDocument
    {
        { "IntegrationId", "$integrationDetails._id" },
        { "IntegrationName", "$integrationDetails.IntegrationName" },
        { "CompanyId", "$companyIntegrationDetails.CompanyId" },
        { "BaseUrl", "$companyIntegrationDetails.BaseURL" },
        { "AuthKeys", "$companyIntegrationDetails.AuthKeys" },
        { "ScheduledTime", "$ScheduledTime" },
        { "FeatureName", "$featureDetails.FeatureName" },
        { "EndPoint", "$featureDetails.EndPoint" },
        { "HttpMethod", "$featureDetails.HttpMethod" },
        { "TimeChampEndPoint", "$featureDetails.TimeChampEndPoint" },
        { "TimeChampHttpMethod", "$featureDetails.TimeChampHttpMethod" },
        { "JobIds", "$JobIds" },
        { "DataToTimeChamp", "$featureDetails.DataToTimeChamp" }
    })
};

        public static BsonDocument[] GetAScheduledFeature(ObjectId objectId)
        {
            BsonDocument[] ScheduledFeatuer = new[]
{
    // Step 1: Join SubscribedIntegrationFeatures with IntegrationFeatures
    new BsonDocument("$lookup", new BsonDocument
    {
        { "from", "IntegrationFeatures" },
        { "localField", "IntegrationFeatureId" },
        { "foreignField", "_id" },
        { "as", "featureDetails" }
    }),
    // Step 2: Unwind the featureDetails array
    new BsonDocument("$unwind", "$featureDetails"),
    
    // Step 3: Join SubscribedIntegrationFeatures with CompanySubscribedIntegrations
    new BsonDocument("$lookup", new BsonDocument
    {
        { "from", "CompanySubscribedIntegrations" },
        { "localField", "SubscribedIntegrationId" },
        { "foreignField", "_id" },
        { "as", "companyIntegrationDetails" }
    }),
    // Step 4: Unwind the companyIntegrationDetails array
    new BsonDocument("$unwind", "$companyIntegrationDetails"),

    // Step 5: Join CompanySubscribedIntegrations with Integrations
    new BsonDocument("$lookup", new BsonDocument
    {
        { "from", "Integrations" },
        { "localField", "companyIntegrationDetails.IntegrationId" },
        { "foreignField", "_id" },
        { "as", "integrationDetails" }
    }),
    // Step 6: Unwind the integrationDetails array
    new BsonDocument("$unwind", "$integrationDetails"),

    // Step 7: Project the final fields for FeatureScheduler
    new BsonDocument("$project", new BsonDocument
    {
        { "IntegrationId", "$integrationDetails._id" },
        { "IntegrationName", "$integrationDetails.IntegrationName" },
        { "CompanyId", "$companyIntegrationDetails.CompanyId" },
        { "BaseUrl", "$companyIntegrationDetails.BaseURL" },
        { "AuthKeys", "$companyIntegrationDetails.AuthKeys" },
        { "ScheduledTime", "$ScheduledTime" },
        { "FeatureName", "$featureDetails.FeatureName" },
        { "EndPoint", "$featureDetails.EndPoint" },
        { "HttpMethod", "$featureDetails.HttpMethod" },
        { "TimeChampEndPoint", "$featureDetails.TimeChampEndPoint" },
        { "TimeChampHttpMethod", "$featureDetails.TimeChampHttpMethod" },
        { "DataToTimeChamp", "$featureDetails.DataToTimeChamp" }
    })
};

            return ScheduledFeatuer;
        }
    }
}
