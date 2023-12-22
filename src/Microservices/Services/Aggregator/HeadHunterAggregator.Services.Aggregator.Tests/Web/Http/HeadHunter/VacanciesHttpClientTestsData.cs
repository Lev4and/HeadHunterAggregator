namespace HeadHunterAggregator.Services.Aggregator.Tests.Web.Http.HeadHunter
{
    public class VacanciesHttpClientTestsData
    {
        public class GetVacanciesInvalidParams : TheoryData<int, int, DateTime, DateTime>
        {
            public GetVacanciesInvalidParams()
            {
                Add(0, 1, DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
                Add(20, 100, DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
                Add(1, 0, DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
                Add(1, 101, DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
                Add(1, 101, DateTime.UtcNow.AddDays(1), DateTime.UtcNow);
            }
        }

        public class GetVacanciesValidParams : TheoryData<int, int, DateTime, DateTime>
        {
            public GetVacanciesValidParams()
            {
                Add(1, 100, DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
            }
        }

        public class GetVacancyOutOfRangeIdParams : TheoryData<long>
        {
            public GetVacancyOutOfRangeIdParams()
            {
                Add(0);
                Add(-1);
            }
        }

        public class GetVacancyNonExistentIdParams : TheoryData<long>
        {
            public GetVacancyNonExistentIdParams()
            {
                Add(long.MaxValue);
            }
        }

        public class GetVacancyExistentIdParams : TheoryData<long>
        {
            public GetVacancyExistentIdParams()
            {
                Add(43425529);
            }
        }
    }
}
