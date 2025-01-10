using MongoDB.Bson;
using Newtonsoft.Json;
using System;

namespace TimeChamp.Integrations.Scheduler.Converters
{


    public class ObjectIdConverter : JsonConverter<ObjectId>
    {
        public override void WriteJson(JsonWriter writer, ObjectId value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override ObjectId ReadJson(JsonReader reader, Type objectType, ObjectId existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string id = reader.Value.ToString();
            return new ObjectId(id);
        }
    }

}
