using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter12
{
    class FakeQueryProvider : IQueryProvider
    {
        public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
        {
            Logger.Log(this);
            Logger.Log(expression);
            return new FakeQuery<TElement>(this, expression);
        }

        public IQueryable CreateQuery(System.Linq.Expressions.Expression expression)
        {
            Type queryType = typeof(FakeQuery<>).MakeGenericType(expression.Type);
            object constructorArguments = new object[] { this, expression };
            return (IQueryable)Activator.CreateInstance(queryType, constructorArguments);
        }

        public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
        {
            Logger.Log(this);
            Logger.Log(expression);
            return default(TResult);
        }

        public object Execute(System.Linq.Expressions.Expression expression)
        {
            Logger.Log(this);
            Logger.Log(expression);
            return default(object);
        }
    }
}
