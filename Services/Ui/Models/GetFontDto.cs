
using System.Drawing;
using System.Drawing.Text;

namespace Services.Ui.Models {
    public class GetFontDto {
        public PrivateFontCollection Collection { get; init; }
        public Font DefaultFont { get; init; }
        public FontFamily DefaultFontFamily { get; init; }
        public float DefaultFontSize { get; init; }
    }
}
