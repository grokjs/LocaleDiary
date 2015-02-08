using System.Linq;

namespace LocaleDiary.Data.Query
{
    public interface IQuery<out T>
    {
        IQueryable<T> Execute(int userId);
    }
}