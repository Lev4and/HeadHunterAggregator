using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.Extensions.Projection
{
    public static class VacancyProjectionExtensions
    {
        public static ProjectionDefinition<Vacancy> WithoutDescriptions(this ProjectionDefinitionBuilder<Vacancy> builder)
        {
            return builder
                .Exclude(vacancy => vacancy.Description)
                .Exclude(vacancy => vacancy.BrandedDescription)
                .Exclude(vacancy => vacancy.Employer.Description)
                .Exclude(vacancy => vacancy.Employer.BrandedDescription);
        }

        public static ProjectionDefinition<Vacancy> WithoutDescriptions(this ProjectionDefinition<Vacancy> builder)
        {
            return builder
                .Exclude(vacancy => vacancy.Description)
                .Exclude(vacancy => vacancy.BrandedDescription)
                .Exclude(vacancy => vacancy.Employer.Description)
                .Exclude(vacancy => vacancy.Employer.BrandedDescription);
        }
    }
}
