using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Common.Utilities {
    public static class DataAnotationEtentions {

        public static string? GetDisplayName(this PropertyInfo obj) {
            var display = obj.GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();
            return display?.Name;
        }

        public static string? GetDisplayName<T>(this T obj) {
            var type = typeof(T);
            var display = type.GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();
            return display?.Name;
        }

        public static string GetPropertyDisplayNameOrName<T>(
            this T obj,
            Expression<Func<T, object>> func,
            [CallerArgumentExpression(nameof(obj))] string objName = ""
            ) {
            var member = GetPropertyInformation(func.Body);
            return member.GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault()?.Name ?? objName;
        }


        public static string GetDisplayNameOrObjectName<T>(
            this T obj,
            [CallerArgumentExpression(nameof(obj))] string objName = ""
            ) {
            var displayName = obj.GetDisplayName();
            return displayName ?? objName ?? "[]";
        }

        public static string GetDisplayNameOrValue<T>(this T obj) {
            var displayName = obj.GetDisplayName();
            return displayName ?? obj.ToString() ?? "[]";
        }


        public static MemberInfo GetPropertyInformation(Expression propertyExpression) {
            Debug.Assert(propertyExpression != null, "propertyExpression != null");
            MemberExpression memberExpr = propertyExpression as MemberExpression;
            if (memberExpr == null) {
                UnaryExpression unaryExpr = propertyExpression as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert) {
                    memberExpr = unaryExpr.Operand as MemberExpression;
                }
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property) {
                return memberExpr.Member;
            }

            return null;
        }
    }
}
