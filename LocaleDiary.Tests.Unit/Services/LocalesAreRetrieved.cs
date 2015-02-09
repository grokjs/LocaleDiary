using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LocaleDiary.Core.Entities;
using LocaleDiary.Data.Ef;
using LocaleDiary.Data.Ef.Repositories;
using LocaleDiary.Data.Repositories;
using LocaleDiary.Services;
using LocaleDiary.Tests.Unit.Infrastructure;
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
        #region Private Properties
        private int _localeId;
        private Guid _userId;
        private List<Guid> _guids = new GuidList();
        private IQueryable<Locale> _locales;

        private readonly Mock<DbSet<Locale>> _mockSet
            = new Mock<DbSet<Locale>>();
        private readonly Mock<LocaleDiaryContext> _mockContext
            = new Mock<LocaleDiaryContext>();

        private ILocaleRepository _localeRepository;
        private LocaleService _localeService;
        private List<Locale> _userLocales;
        private Locale _locale;
        #endregion

        #region Given
        public void GivenAUserId(Guid userId)
        {
            _userId = userId;
        }

        public void GivenALocaleId(int localeId)
        {
            _localeId = localeId;
        }

        public void AndGivenThatTheUserHasNoLocales()
        {
            _locales = TestLocaleData();
            Assert.That(_locales.Any(x => x.UserId == _userId), Is.False);
        }

        public void AndGivenThatTheUserHasLocales()
        {
            _locales = TestLocaleData();
            Assert.That(_locales.Any(x => x.UserId == _userId), Is.True);
        }

        public void AndGivenThatTheLocaleDoesNotExist()
        {
            _locales = TestLocaleData();
            Assert.That(_locales.FirstOrDefault(x => x.Id == _localeId), Is.Null);
        }

        public void AndGivenThatTheLocaleExists()
        {
            _locales = TestLocaleData();
            Assert.That(_locales.FirstOrDefault(x => x.Id == _localeId), Is.Not.Null);
        }
        #endregion

        #region When
        public void WhenTheLocalesAreRetrieved()
        {
            SetUpMock();
            _localeRepository = new LocaleRepository(_mockContext.Object);
            _localeService = new LocaleService(_localeRepository);
            _userLocales = _localeService.GetLocalesForUser(_userId);
        }

        public void WhenTheLocaleIsRetrieved()
        {
            SetUpMock();
            _localeRepository = new LocaleRepository(_mockContext.Object);
            _localeService = new LocaleService(_localeRepository);
            _locale = _localeService.GetLocaleById(_localeId);
        }
        #endregion

        #region Then
        public void ThenNoLocalesAreReturned()
        {
            Assert.That(_userLocales.Count(), Is.EqualTo(0));
        }

        public void ThenTheExpectedNumberOfLocalesAreReturned()
        {
            Assert.That(_userLocales.Count(), Is.EqualTo(2));
        }

        public void ThenNoLocaleIsReturned()
        {
            Assert.That(_locale, Is.Null);
        }

        public void ThenTheCorrectLocaleIsReturned()
        {
            Assert.That(_locale, Is.InstanceOf<Locale>());
            Assert.That(_locale.Id, Is.EqualTo(_localeId));
        }
        #endregion

        #region Tests
        [Test]
        public void AccountHasNoLocalesDefined()
        {
            this.Given(x => x.GivenAUserId(_guids[9]))
                .And(x => x.AndGivenThatTheUserHasNoLocales())
                .When(x => x.WhenTheLocalesAreRetrieved())
                .Then(x => x.ThenNoLocalesAreReturned())
                .BDDfy<LocalesAreRetrieved>();
        }

        [Test]
        public void AccountHasLocalesDefined()
        {
            this.Given(x => x.GivenAUserId(_guids[0]))
                .And(x => x.AndGivenThatTheUserHasLocales())
                .When(x => x.WhenTheLocalesAreRetrieved())
                .Then(x => x.ThenTheExpectedNumberOfLocalesAreReturned())
                .BDDfy<LocalesAreRetrieved>();
        }

        [Test]
        public void LocaleByIdNotDefined()
        {
            this.Given(x => x.GivenALocaleId(100))
                .And(x => x.AndGivenThatTheLocaleDoesNotExist())
                .When(x => x.WhenTheLocaleIsRetrieved())
                .Then(x => x.ThenNoLocaleIsReturned())
                .BDDfy<LocalesAreRetrieved>();
        }

        [Test]
        public void LocalesRetrievedById()
        {
            this.Given(x => x.GivenALocaleId(1))
                .And(x => x.AndGivenThatTheLocaleExists())
                .When(x => x.WhenTheLocaleIsRetrieved())
                .Then(x => x.ThenTheCorrectLocaleIsReturned())
                .BDDfy<LocalesAreRetrieved>();
        }
        #endregion

        #region Private Methods
        private IQueryable<Locale> TestLocaleData()
        {
            return new List<Locale>
            {
                new Locale {Id = 1, Name = "First Locale", UserId = _guids[0]},
                new Locale {Id = 2, Name = "Second Locale", UserId = _guids[0]},
                new Locale {Id = 3, Name = "Third Locale", UserId = _guids[1]}
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
        #endregion
    }
}