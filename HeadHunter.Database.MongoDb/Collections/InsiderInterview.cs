using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    public class InsiderInterview
    {
        [BsonIgnoreIfNull]
        [BsonElement("headHunterId")]
        public string? HeadHunterId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("title")]
        public string? Title { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("url")]
        public string? Url { get; set; }

        public InsiderInterview()
        {

        }

        public InsiderInterview(Models.InsiderInterview insiderInterview)
        {
            if (insiderInterview == null)
            {
                throw new ArgumentNullException(nameof(insiderInterview));
            }

            HeadHunterId = insiderInterview.Id;
            Title = insiderInterview.Title;
            Url = insiderInterview.Url;
        }
    }
}
