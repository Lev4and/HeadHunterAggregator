namespace HeadHunterAggregator.Services.Aggregator.Tests.Web.Http.HeadHunter
{
    public class EmployersHttpClientTestsData
    {
        public class GetEmployerOutOfRangeIdParams : TheoryData<long>
        {
            public GetEmployerOutOfRangeIdParams()
            {
                Add(0);
                Add(-1);
            }
        }

        public class GetEmployerNonExistentIdParams : TheoryData<long> 
        {
            public GetEmployerNonExistentIdParams() 
            {
                Add(long.MaxValue);
            }
        }

        public class GetEmployerExistentIdParams : TheoryData<long>
        {
            public GetEmployerExistentIdParams() 
            {
                Add(1);
            }
        }
    }
}
