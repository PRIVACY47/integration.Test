using Newtonsoft.Json;
using TimeChamp.Integraions.MainEngine.ApiCalls;
using TimeChamp.Integraions.MainEngine.Models;

namespace TimeChamp.Integraions.MainEngine.AdaptarServiceRouter
{
    public class AdaptarService
    {
        public ApiCaller _apiCaller;
        public AdaptarService(ApiCaller apiCaller)
        {
            _apiCaller = apiCaller;
        }



        public async Task<string> MakeApiCall(ScheduledFeaturesDeserialization  data)
        {
            //based on the data resovle the endponits 
            string dataToInsertINQueue = await _apiCaller.MakeApiCallAsync("https://localhost:7001", "api/KekaAdapter/GetUtc", JsonConvert.SerializeObject(data));

            return dataToInsertINQueue;

        }
    }
}
