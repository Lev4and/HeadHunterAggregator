using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    public class Salary
    {
        [BsonIgnoreIfNull]
        [BsonElement("gross")]
        public bool? Gross { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("to")]
        public decimal? To { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("from")]
        public decimal? From { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("currency")]
        public Currency? Currency { get; set; }

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
