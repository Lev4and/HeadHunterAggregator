using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("addresses")]
    public class Address : ICollection
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("city")]
        public string City { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("street")]
        public string Street { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("building")]
        public string Building { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("latitude")]
        public double? Latitude { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("longitude")]
        public double? Longitude { get; set; }

        public Address(Models.Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            City = address.City;
            Street = address.Street;
            Building = address.Building;
            Description = address.Description;
            Latitude = address.Lat;
            Longitude = address.Lng;
        }
    }
}
