namespace HeadHunterAggregator.Domain.Entities
{
    public interface IGeoLocation
    {
        double Latitude { get; set; }

        double Longitude { get; set; }
    }
}
