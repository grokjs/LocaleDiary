using LocaleDiary.Data.Repositories;

namespace LocaleDiary.Services
{
    public class ServiceBase
    {
        protected readonly ILocaleRepository Locales;

        public ServiceBase(ILocaleRepository locales)
        {
            Locales = locales;
        }
    }
}