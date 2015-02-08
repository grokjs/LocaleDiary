using System.Collections.Generic;
using System.Linq;
using LocaleDiary.Core.Entities;
using LocaleDiary.Data.Query;
using LocaleDiary.Data.Repositories;

namespace LocaleDiary.Services
{
    public class LocaleService : ServiceBase
    {
        public LocaleService(ILocaleRepository locales) : base(locales)
        {
        }

        public List<Locale> GetLocalesForUser(int userId)
        {
            var query = new ListLocalesQuery()
                .WithUser(userId);
            
            return Locales.GetLocales(query).ToList();
        }
    }
}