using HeadHunter.Database.MongoDb.Common.JsonConverters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Collections
{
    public class Salary
    {
        [BsonIgnoreIfNull]
        [BsonElement("currencyId")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId? CurrencyId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("gross")]
        public bool? Gross { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("to")]
        public decimal? To { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("from")]
        public decimal? From { get; set; }

        public Currency? Currency { get; set; }

        public Salary()
        {

        }

        public Salary(Models.Salary salary)
        {
            if (salary == null)
            {
                throw new ArgumentNullException(nameof(salary));
            }

            Gross = salary.Gross;
            To = salary.To;
            From = salary.From;
            Currency = new Currency(new Models.Currency { Code = salary.Currency });
        }
    }
}
