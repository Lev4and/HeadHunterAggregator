using HeadHunter.Core.Abstracts;
using HeadHunter.MongoDB.Core.Factories;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace HeadHunter.MongoDB.Core.Conventions
{
    public class GuidAsStringRepresentationConvention : ConventionBase, IMemberMapConvention
    {
        private readonly IEnumerable<Type> _validTypes;
        private readonly IFactory<Type, IBsonSerializer> _factory;

        public GuidAsStringRepresentationConvention()
        {
            _validTypes = new List<Type>
            {
                typeof(Guid),
                typeof(Guid?),
                typeof(Guid[])
            };

            _factory = new GuidSerializerFactory();
        }

        public void Apply(BsonMemberMap memberMap)
        {
            if (_validTypes.Contains(memberMap.MemberType))
            {
                memberMap.SetSerializer(_factory.Create(memberMap.MemberType));
            }
        }
    }
}
