using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Projection
{
    public static class EmployerProjectionExtensions
    {
        public static ProjectionDefinition<Employer> WithoutDescriptions(this ProjectionDefinitionBuilder<Employer> builder)
        {
            return builder
                .Exclude(employer => employer.Description)
                .Exclude(employer => employer.BrandedDescription);
        }

        public static ProjectionDefinition<Employer> WithoutDescriptions(this ProjectionDefinition<Employer> builder)
        {
            return builder
                .Exclude(employer => employer.Description)
                .Exclude(employer => employer.BrandedDescription);
        }
    }
}
