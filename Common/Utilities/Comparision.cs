using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Common.Utilities {

    public static class Comparision {
        public static List<Variance> Compare<T>(this T val1, T val2, Type? NotAllowdBaseInterface = null) {
            var variances = new List<Variance>();
            var properties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => !x.GetMethod.IsVirtual)
                //.Where(x => !x.GetAccessors().Any(a => a.IsVirtual))
                .OrderBy(x => x.GetCustomAttributes<OrderAttribute>(false).FirstOrDefault()?.Order ?? 0)
                .ToList();

            if (NotAllowdBaseInterface is not null) {
                properties = properties
                .Where(x => !x.PropertyType.GetInterfaces().Any(i => i == NotAllowdBaseInterface))
                .ToList();
            }
            foreach (var property in properties) {
                var isEnum = property.PropertyType.BaseType == typeof(Enum);

                var val1Str = property.GetValue(val1);
                var val2Str = val2 is null ? null : property.GetValue(val2);
                if (isEnum) {
                    val1Str = property.PropertyType
                        .GetField(property.GetValue(val1).ToString() ?? "")?
                        .GetCustomAttributes<DisplayAttribute>().FirstOrDefault()?.Name ?? val1Str;

                    val2Str = val2 is null ? null : property.PropertyType
                        .GetField(property.GetValue(val2).ToString() ?? "")?
                        .GetCustomAttributes<DisplayAttribute>().FirstOrDefault()?.Name ?? val2Str;
                }

                var v = new Variance {
                    PropName = property.GetDisplayName() ?? property.Name,
                    valA = val1Str.NullIfEmpty(),
                    valB = val2 == null ? null : val2Str.NullIfEmpty()
                };
                if (v.valA == null && v.valB == null) {
                    continue;
                }
                if (
                    (v.valA == null && v.valB != null)
                    ||
                    (v.valA != null && v.valB == null)
                ) {
                    variances.Add(v);
                    continue;
                }
                if (!v.valA.Equals(v.valB)) {
                    variances.Add(v);
                }
            }
            return variances;
        }

        public static string? Print(this List<Variance> variances) {
            var lines = variances.Select(x => $"[{x.PropName.GetDisplayNameOrValue()}]: {{{x.valA}}} => {{{x.valB}}}");

            return lines.Count() == 0 ? null : string.Join("\n", lines);
        }

        public static string? PrintA(this List<Variance> variances) {
            var lines = variances.Select(x => $"[{x.PropName.GetDisplayNameOrValue()}]: {{{x.valA}}}");

            return lines.Count() == 0 ? null : string.Join("\n", lines);
        }
    }

    public class Variance {
        public string PropName { get; set; }
        public object valA { get; set; }
        public object valB { get; set; }
    }
}
