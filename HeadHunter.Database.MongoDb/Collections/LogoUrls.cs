using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    public class LogoUrls
    {
        [BsonIgnoreIfNull]
        [BsonElement("original")]
        public string? Original { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("ninetyByNinety")]
        public string? NinetyByNinety { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("twoHundredFortyByTwoHundredForty")]
        public string? TwoHundredFortyByTwoHundredForty { get; set; }

        public LogoUrls()
        {

        }

        public LogoUrls(Models.LogoUrls logoUrls)
        {
            if (logoUrls == null)
            {
                throw new ArgumentNullException(nameof(logoUrls));
            }

            Original = logoUrls.Original;
            NinetyByNinety = logoUrls._90;
            TwoHundredFortyByTwoHundredForty = logoUrls._240;
        }
    }
}
