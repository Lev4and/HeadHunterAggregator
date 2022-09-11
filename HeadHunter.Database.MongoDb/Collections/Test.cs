using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    public class Test
    {
        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        public Test(Models.Test test)
        {
            if (test == null)
            {
                throw new ArgumentNullException(nameof(test));
            }

            HeadHunterId = test.Id;
            Name = test.Name;
        }
    }
}
