using System.Reflection;

namespace Common.Utilities {

    public static class Comparision {
        public static List<Variance> Compare<T>(this T val1, T val2) {
            var variances = new List<Variance>();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties) {
                var v = new Variance {
                    PropName = property.Name,
                    valA = property.GetValue(val1),
                    valB = property.GetValue(val2)
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

        public static string? ToString(this List<Variance> variances) {
            string? output = null;
            foreach (var item in variances) {
                output += $"\n'{item.GetDisplayNameOrObjectName()}': [{item.valA}] => [{item.valB}]";
            }

            return output is null ? null : output.Substring(1);
        }
    }

    public class Variance {
        public string PropName { get; set; }
        public object valA { get; set; }
        public object valB { get; set; }
    }
}
