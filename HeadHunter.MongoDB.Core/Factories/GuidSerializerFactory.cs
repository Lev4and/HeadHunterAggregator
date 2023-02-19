using HeadHunter.Core.Abstracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace HeadHunter.MongoDB.Core.Factories
{
    public class GuidSerializerFactory : IFactory<Type, IBsonSerializer>
    {
        private readonly Dictionary<Type, IBsonSerializer> _serializers = new Dictionary<Type, IBsonSerializer>
        {
            { typeof(Guid), new GuidSerializer(BsonType.String) },
            { typeof(Guid?), new NullableSerializer<Guid>(new GuidSerializer(BsonType.String)) },
            { typeof(Guid[]), new ArraySerializer<Guid>(new GuidSerializer(BsonType.String)) }
        };

        public IBsonSerializer Create(Type input)
        {
            if (!_serializers.ContainsKey(input)) throw new ArgumentException(nameof(input));

            return _serializers[input];
        }
    }
}
