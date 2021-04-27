using System.Collections.Generic;
using System.Linq;

namespace Dotnet6.GraphQL4.Domain.Abstractions.ValueObjects
{
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
            => (ReferenceEquals(left, null) ^ ReferenceEquals(right, null)) is false && 
               (ReferenceEquals(left, null) || left.Equals(right));

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
            => EqualOperator(left, right) is false;

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
            => obj is not null && obj.GetType() == GetType() && 
               GetEqualityComponents().SequenceEqual(((ValueObject) obj).GetEqualityComponents());

        public override int GetHashCode()
            => GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
    }
}