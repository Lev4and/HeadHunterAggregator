namespace HeadHunterAggregator.Domain.Entities
{
    public interface ITreeStructure
    {
        Guid? ParentId { get; set; }
    }
}
