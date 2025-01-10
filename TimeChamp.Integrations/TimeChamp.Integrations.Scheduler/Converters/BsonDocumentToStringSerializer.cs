using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;


namespace TimeChamp.Integrations.Scheduler.Converters
{
    public class BsonDocumentToStringSerializer : SerializerBase<BsonDocument>
    {
        public override BsonDocument Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var value = context.Reader.ReadString();
            return value == null ? null : BsonDocument.Parse(value);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, BsonDocument value)
        {
            if (value == null)
            {
                context.Writer.WriteString(null);
            }
            else
            {
                context.Writer.WriteString(value.ToString());
            }
        }
    }
}
