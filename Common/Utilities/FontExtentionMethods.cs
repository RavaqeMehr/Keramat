using System.Drawing;

namespace Common.Utilities {
    public static class FontExtentionMethods {
        public static Font ByRatio(this Font self, double ratio = 1) {
#pragma warning disable CA1416 // Validate platform compatibility
            return new Font(self.FontFamily, self.Size * (float)ratio);
#pragma warning restore CA1416 // Validate platform compatibility
        }
    }
}
