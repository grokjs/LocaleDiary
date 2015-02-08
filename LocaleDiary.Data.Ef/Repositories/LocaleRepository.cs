using System.Linq;
using LocaleDiary.Core.Entities;
using LocaleDiary.Data.Query;
using LocaleDiary.Data.Repositories;

namespace LocaleDiary.Data.Ef.Repositories
{
    public class LocaleRepository : ILocaleRepository
    {
        private readonly LocaleDiaryContext _context;

        public LocaleRepository(LocaleDiaryContext context)
        {
            _context = context;
        }

        public IQueryable<Locale> GetLocales(ListLocalesQuery query)
        {
            return _context.Locales.Where(query.AsExpression());
        }
    }
}