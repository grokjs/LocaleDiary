using LocaleDiary.Core.Entities;

namespace LocaleDiary.Data.Query
{
    public class ListLocalesQuery : QueryBase<Locale>
    {
        public ListLocalesQuery WithUser(int userId)
        {
            AddCriteria(x => x.UserId == userId);
            return this;
        }

        public ListLocalesQuery WithLocale(int localeId)
        {
            AddCriteria(x => x.Id == localeId);
            return this;
        }
    }
}