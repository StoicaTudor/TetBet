using System;
using System.Collections.Generic;
using NUnit.Framework;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Infrastructure.Services.RapidApi.Fetchers;
using TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football;
using TetBet.Server.Infrastructure.Services.RapidApi.Fetchers.Football.Fetchers;
using TetBet.Server.Infrastructure.Services.RapidApi.RequestService;
using Unity;

namespace TetBet.Server.Infrastructure.Tests.ServiceTests.RapidApiTests.FetchersTests
{
    public class BaseFetcherSandbox
    {
        private BaseApiFetcher _baseApiFetcher;

        [SetUp]
        public void Setup()
        {
            IocConfig.RegisterComponents();
            var testContainer = IocConfig.GetConfiguredContainer();
            var unitOfWork = testContainer.Resolve<IUnitOfWork>();
            unitOfWork.User.Get();

            _baseApiFetcher = new CountriesApiFetcher(
                testContainer.Resolve<IRequestService>(),
                GetUrlParams());
        }

        [Test]
        public void GetResponse()
        {
            Console.WriteLine(_baseApiFetcher
                .Fetch()
                .Content);

            Assert.IsTrue(true);
        }

        private Dictionary<string, object> GetUrlParams()
            => new Dictionary<string, object>();
    }
}