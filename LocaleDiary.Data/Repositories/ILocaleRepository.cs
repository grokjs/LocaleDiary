using System.Linq;
using LocaleDiary.Core.Entities;
using LocaleDiary.Data.Query;

namespace LocaleDiary.Data.Repositories
{
    public interface ILocaleRepository
    {
        IQueryable<Locale> GetLocales(ListLocalesQuery query);
    }
}