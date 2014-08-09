using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chapter12
{
    public class FakeQuery<T> : IQueryable<T>
    {
        internal FakeQuery(IQueryProvider provider, Expression expression)
        {
            Expression = expression;
            Provider = provider;
            ElementType = typeof(T);
        }
        public FakeQuery():this(new FakeQueryProvider(),null) {
            Expression = Expression.Constant(this);
        }
        public IEnumerator<T> GetEnumerator()
        {
            Logger.Log(this.Expression);
            return Enumerable.Empty<T>().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            Logger.Log(this.Expression);
            return Enumerable.Empty<T>().GetEnumerator();
        }

        public Type ElementType
        {
            get;
            private set;
        }

        public System.Linq.Expressions.Expression Expression
        {
            get;
            private set;
        }

        public IQueryProvider Provider
        {
            get;
            private set;
        }
        public override string ToString()
        {
            return "FakeQuery";
        }
    }
}
