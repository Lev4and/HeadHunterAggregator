using HeadHunter.Core.Abstracts;
using HeadHunter.Core.Extensions;
using Entities = HeadHunter.MongoDB.Entities;
using ResponseModels = HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.Infrastructure.Factories.HeadHunter
{
    internal interface IEmployerFactory : IFactory<ResponseModels.Employer, Entities.Employer>
    {

    }

    internal class EmployerFactory : IEmployerFactory
    {
        private readonly ICompressor _compressor;

        private readonly IAreaFactory _areaFactory;
        private readonly IEmployerLogoFactory _employerLogoFactory;

        private readonly IIndustryFactory _industryFactory;
        private readonly IInsiderInterviewFactory _insiderInterviewFactory;

        public EmployerFactory(ICompressor compressor, IAreaFactory areaFactory, 
            IEmployerLogoFactory employerLogoFactory, IIndustryFactory industryFactory, 
            IInsiderInterviewFactory insiderInterviewFactory)
        {
            _compressor = compressor;

            _areaFactory = areaFactory;
            _employerLogoFactory = employerLogoFactory;

            _industryFactory = industryFactory;
            _insiderInterviewFactory = insiderInterviewFactory;
        }

        public Entities.Employer? Create(ResponseModels.Employer input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            return new Entities.Employer
            {
                Trusted = input.Trusted,
                Blacklisted = input.Blacklisted,
                HeadHunterId = long.Parse(input.Id),
                Name = input.Name,
                Url = input.Url,
                Type = input.Type,
                SiteUrl = input.SiteUrl,
                Description = _compressor.Compress(input.Description),
                AlternateUrl = input.AlternateUrl,
                VacanciesUrl = input.VacanciesUrl,
                BrandedDescription = _compressor.Compress(input.BrandedDescription),
                Area = _areaFactory.Create(input.Area),
                Logo = _employerLogoFactory.Create(input.LogoUrls),
                Industries = _industryFactory.CreateArray(input.Industries?.ToArray()),
                InsiderInterviews = _insiderInterviewFactory.CreateArray(input.InsiderInterviews?.ToArray())
            };
        }
    }
}
