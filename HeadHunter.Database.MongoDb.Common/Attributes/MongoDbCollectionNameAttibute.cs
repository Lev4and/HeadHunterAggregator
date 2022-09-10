namespace HeadHunter.Database.MongoDb.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MongoDbCollectionNameAttibute : Attribute
    {
        public string Name { get; }

        public MongoDbCollectionNameAttibute(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }
    }
}
