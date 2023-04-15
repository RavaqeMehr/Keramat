using System.Runtime.CompilerServices;

namespace Common.Utilities {
    public static class DataAnotationEtentions {
        public static string GetDisplayNameOrObjectName(
            this object? obj,
            [CallerArgumentExpression(nameof(obj))] string objName = null
            ) {
            return objName;
            //var type = obj.GetType();
            //return type.Name;
            //var display = type.GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();
            //return display?.Name ?? objName ?? "[]";
            //return display?.GetType().GetProperty("Name")?.GetValue(display, null)?.ToString() ?? objName ?? "[]";
            //return display?.ToJSON() ?? objName ?? "[]";

        }
    }
}
