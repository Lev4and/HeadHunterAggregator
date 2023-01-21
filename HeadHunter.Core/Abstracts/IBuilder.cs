namespace HeadHunter.Core.Abstracts
{
    public interface IBuilder<TOutput>
    {
        TOutput Build();
    }
}
