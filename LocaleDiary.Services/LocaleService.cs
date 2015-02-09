using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public List<Locale> GetLocalesForUser(Guid userId)
        {
            var query = new ListLocalesQuery()
                .WithUser(userId);
            
            return Locales.GetLocales(query).ToList();
        }

        public async Task<List<Locale>> GetLocalesForUserAsync(Guid userId)
        {
            var query = new ListLocalesQuery()
                .WithUser(userId);

            return await Locales.GetLocales(query).ToListAsync();
        }

        public Locale GetLocaleById(int localeId)
        {
            var query = new ListLocalesQuery()
                .WithLocale(localeId);

            return Locales.GetLocales(query).FirstOrDefault();
        }

        public async Task<Locale> GetLocaleByIdAsync(int localeId)
        {
            var query = new ListLocalesQuery()
                .WithLocale(localeId);

            return await Locales.GetLocales(query).FirstOrDefaultAsync();
        }
    }
}