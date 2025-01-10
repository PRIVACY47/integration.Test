using MongoDB.Bson;
using MongoDB.Driver;

namespace TimeChamp.Integrations.Scheduler.DatabaseCommunicator
{
    public class MongoDBConnector
    {
        private readonly IConfiguration _configuration;
        public IMongoDatabase _database ;
        public MongoDBConnector(IConfiguration configuration)
        {
            _configuration = configuration;
            string? connectionUri = _configuration.GetConnectionString("MongoDBConnectionSting");
            MongoClient client = new MongoClient(connectionUri);
            _database = client.GetDatabase("demo");
        }
        public bool ConnectToDataBase(string dataBase= "demo")
        {
            string? connectionUri = _configuration.GetConnectionString("MongoDBConnectionSting");
            if(!string.IsNullOrWhiteSpace(connectionUri))
            {
                MongoClient client = new MongoClient(connectionUri);
                try
                {
                    _database = client.GetDatabase(dataBase);
                    return true;
                }
                catch (Exception ex) 
                {
                    return false; 
                }
            }
            else
            {
                return false;
            }
            
        }
    }
}
