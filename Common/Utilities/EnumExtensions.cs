#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CA2248 // Provide correct 'enum' argument to 'Enum.HasFlag'
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Common.Utilities {
    public static class EnumExtensions {
        public static IEnumerable<T> GetEnumValues<T>(this T input) where T : struct {
            if (!typeof(T).IsEnum) {
                throw new NotSupportedException();
            }

            return Enum.GetValues(input.GetType()).Cast<T>();
        }

        public static IEnumerable<T> GetEnumFlags<T>(this T input) where T : struct {
            if (!typeof(T).IsEnum) {
                throw new NotSupportedException();
            }

            foreach (var value in Enum.GetValues(input.GetType())) {
                if ((input as Enum).HasFlag(value as Enum)) {
                    yield return (T)value;
                }
            }
        }

        public static string ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name) {
            Assert.NotNull(value, nameof(value));

            var attribute = value.GetType().GetField(value.ToString())
                .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

            if (attribute == null) {
                return value.ToString();
            }

            var propValue = attribute.GetType().GetProperty(property.ToString()).GetValue(attribute, null);
            try {
                return propValue.ToString();
            }
            catch (Exception) {
                return value.ToString();
            }
        }

        public static Dictionary<int, string> ToDictionary(this Enum value) {
            return Enum.GetValues(value.GetType()).Cast<Enum>().ToDictionary(p => Convert.ToInt32(p), q => ToDisplay(q));
        }

        public static IdNameDisplay[] ToArrayOfIdNameDisplay(this Enum value) {
            return Enum.GetValues(value.GetType()).Cast<Enum>()
                .Select(x => new IdNameDisplay {
                    Id = Convert.ToInt32(x),
                    Name = x.ToString(),
                    Display = x.ToDisplay()
                })
                .ToArray();
        }

        public class IdNameDisplay {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Display { get; set; }
        }
    }

    public enum DisplayProperty {
        Description,
        GroupName,
        Name,
        Prompt,
        ShortName,
        Order
    }
}

#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CA2248 // Provide correct 'enum' argument to 'Enum.HasFlag'
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.