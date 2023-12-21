namespace HeadHunterAggregator.Services.Aggregator.Tests.Web.Http.HeadHunter
{
    public class EmployersHttpClientTestsData
    {
        public class OutOfRangeIdParams : TheoryData<long>
        {
            public OutOfRangeIdParams()
            {
                Add(0);
                Add(-1);
            }
        }
    }
}
