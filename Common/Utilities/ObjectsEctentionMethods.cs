using Newtonsoft.Json;

namespace Common.Utilities {
    public static class ObjectsEctentionMethods {
        public static T Clone<T>(this T self) {
            var serialized = JsonConvert.SerializeObject(self);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}


