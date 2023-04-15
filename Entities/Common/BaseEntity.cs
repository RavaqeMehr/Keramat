using Common.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace Entities.Common {
    public interface IEntity {
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public abstract class BaseEntity<TKey> : IEntity {
        [Order(-100)]
        [Display(Name = "کد")]
        public TKey Id { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public abstract class BaseEntity : BaseEntity<int> {
    }


#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable IDE0019 // Use pattern matching
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
    public static class EntityExtentions {
        public static int? GetMaxLength<TSource, TProperty>(
            this IEntity source, Expression<Func<TSource, TProperty>> expression
            ) {
            Type type = typeof(TSource);
            MemberExpression member = expression.Body as MemberExpression;

            if (member is null)
                return null;

            PropertyInfo propertyInfo = member.Member as PropertyInfo;

            if (propertyInfo is null)
                return null;

            if (type != propertyInfo.ReflectedType && !type.IsSubclassOf(propertyInfo.ReflectedType))
                return null;
            var output = propertyInfo.CustomAttributes;
            if (propertyInfo.CustomAttributes.Count(x => x.AttributeType == typeof(MaxLengthAttribute)) > 0) {
                return propertyInfo.GetCustomAttribute<MaxLengthAttribute>().Length;
            }
            else if (propertyInfo.CustomAttributes.Count(x => x.AttributeType == typeof(StringLengthAttribute)) > 0) {
                return propertyInfo.GetCustomAttribute<StringLengthAttribute>().MaximumLength;
            }
            return -1;
        }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore IDE0019 // Use pattern matching
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}
