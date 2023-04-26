namespace KeramatUIControls.Common {
    public enum InputColors {
        Normal,
        Red,
        Green,
        Blue
    }

    public static class InputColorsExtentions {
        public static Color ToColor(this InputColors self) {
            switch (self) {
                case InputColors.Normal:
                    return Color.Black;
                case InputColors.Red:
                    return Color.Red;
                case InputColors.Green:
                    return Color.Green;
                case InputColors.Blue:
                    return Color.Blue;

                default:
                    return Color.Black;
            }
        }
    }
}
