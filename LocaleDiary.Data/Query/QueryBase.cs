using System;
using System.Linq.Expressions;
using LocaleDiary.Data.Helpers;

namespace LocaleDiary.Data.Query
{
    public abstract class QueryBase<T>
    {
        private Expression<Func<T, bool>> _expression;

        public Expression<Func<T, bool>> AsExpression()
        {
            return _expression;
        }

        public Expression<Func<T, bool>> AndAlso(QueryBase<T> otherQuery)
        {
            return AsExpression().AndAlso(otherQuery.AsExpression());
        }

        public Expression<Func<T, bool>> OrElse(QueryBase<T> otherQuery)
        {
            return AsExpression().OrElse(otherQuery.AsExpression());
        }

        protected void AddCriteria(Expression<Func<T, bool>> nextExpression)
        {
            _expression = (_expression == null)
                ? nextExpression
                : _expression.AndAlso(nextExpression);
        }
    }
}