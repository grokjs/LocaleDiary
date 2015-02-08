using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LocaleDiary.Core.Entities;
using LocaleDiary.Data.Ef;
using LocaleDiary.Data.Ef.Repositories;
using LocaleDiary.Data.Repositories;
using LocaleDiary.Services;
using Moq;
using NUnit.Framework;
using TestStack.BDDfy;

namespace LocaleDiary.Tests.Unit.Services
{
    [TestFixture]
    [Story(
        AsA = "As a user",
        IWant = "I want to retrieve my locales",
        SoThat = "So that I can view my data")]
    public class LocalesAreRetrieved
    {
        private int _userId;
        private IQueryable<Locale> _locales;

        private readonly Mock<DbSet<Locale>> _mockSet
            = new Mock<DbSet<Locale>>();
        private readonly Mock<LocaleDiaryContext> _mockContext
            = new Mock<LocaleDiaryContext>();

        private ILocaleRepository _localeRepository;
        private LocaleService _localeService;
        private List<Locale> _userLocales;

        public void GivenAUserId(int userId)
        {
            _userId = userId;
        }

        public void AndGivenThatTheUserHasNoLocales()
        {
            _locales = TestLocaleData();
        }

        public void WhenTheLocalesAreRetrieved()
        {
            SetUpMock();
            _localeRepository = new LocaleRepository(_mockContext.Object);
            _localeService = new LocaleService(_localeRepository);
            _userLocales = _localeService.GetLocalesForUser(_userId);
        }

        public void ThenNoLocalesAreReturned()
        {
            Assert.That(_userLocales.Count(), Is.EqualTo(0));
        }

        [Test]
        public void AccountHasNoLocalesDefined()
        {
            this.Given(x => x.GivenAUserId(100))
                .And(x => x.AndGivenThatTheUserHasNoLocales())
                .When(x => x.WhenTheLocalesAreRetrieved())
                .Then(x => x.ThenNoLocalesAreReturned())
                .BDDfy<LocalesAreRetrieved>();
        }

        private static IQueryable<Locale> TestLocaleData()
        {
            return new List<Locale>
            {
                new Locale {Id = 1, Name = "First Locale", UserId = 1}
            }.AsQueryable();
        }

        private void SetUpMock()
        {
            _mockSet.As<IQueryable<Locale>>()
                .Setup(x => x.Provider).Returns(_locales.Provider);
            _mockSet.As<IQueryable<Locale>>()
                .Setup(x => x.Expression).Returns(_locales.Expression);
            _mockSet.As<IQueryable<Locale>>()
                .Setup(x => x.ElementType).Returns(_locales.ElementType);
            _mockSet.As<IQueryable<Locale>>()
                .Setup(x => x.GetEnumerator()).Returns(_locales.GetEnumerator());
            _mockContext.Setup(x => x.Locales).Returns(_mockSet.Object);
        }
    }
}