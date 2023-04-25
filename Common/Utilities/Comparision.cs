﻿using System.Reflection;

namespace Common.Utilities {

    public static class Comparision {
        public static List<Variance> Compare<T>(this T val1, T val2) {
            var variances = new List<Variance>();
            var properties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => !x.GetMethod.IsVirtual)
                .OrderBy(x => x.GetCustomAttributes<OrderAttribute>(false).FirstOrDefault()?.Order ?? 0);
            foreach (var property in properties) {
                var v = new Variance {
                    PropName = property.GetDisplayName() ?? property.Name,
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
