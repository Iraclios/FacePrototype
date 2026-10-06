using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FacePrototype.Components.Pages
{
    internal class ProjectionPoint
    {
        public string Name { get; private set; }
        private double result;
        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                BackgroundColor = result switch
                {
                    > 100 => Color.White,
                    > 85 => Color.Green,
                    > 78 => Color.Lime,
                    > 65 => Color.Yellow,
                    >= 55 => Color.Orange,
                    > 34 => Color.Red,
                    > 10 => Color.Burgundy,
                    _ => Color.White
                };
                FontColor = BackgroundColor == Color.Burgundy ? Color.White : Color.Black;
            }
        }
        public double StressResult1 { get; set; }
        public double StressResult2 { get; set; }
        public double CoordinateX { get; private set; }
        public double CoordinateY { get; private set; }
        public Color BorderColor { get; private set; }
        public Color BackgroundColor { get; private set; }
        public Color FontColor { get; private set; }
        public bool IsVisible { get; set; }
        [JsonConstructor]
        public ProjectionPoint(string name, Color borderColor, double coordinateX = 0, double coordinateY = 0, bool isVisible = false)
        {
            IsVisible = isVisible;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Name = name;
            BorderColor = borderColor;
            Result = 0;
            StressResult1 = 0;
            StressResult2 = 0;
        }
        public string GetStyle()
        {
            string backgroundColor = BackgroundColor.GetRGB();
            string borderColor = BorderColor.GetRGB();
            string fontColor = FontColor.GetRGB();
            string isVisible = IsVisible ? "visible" : "hidden";
            string css = $"background-color: {backgroundColor}; color: {fontColor}; border-color: {borderColor}; " +
                $"visibility: {isVisible}; left: {CoordinateX}%; top: {CoordinateY}%;";
            return css;
        }
    }
    struct Point2D
    {
        public double CoordinateX { get; private set; }
        public double CoordinateY { get; private set; }
        [JsonConstructor]
        public Point2D(double x = 0, double y = 0)
        {
            CoordinateX = x;
            CoordinateY = y;
        }
    }
    public enum Color
    {
        Black,
        Burgundy,
        Red,
        Orange,
        Yellow,
        Lime,
        Green,
        White,
        Brown,
        Blue,
        Purple,
        Gold,
        DarkGreen,
        Gray
    }
    static class ColorEnumExtension
    {
        public static string GetRGB(this Color color)
        {
            return color switch
            {
                Color.White => "#FFFFFF",
                Color.Black => "#000000",
                Color.Green => "#00AF64",
                Color.Lime => "#67E300",
                Color.Yellow => "#FCFC00",
                Color.Orange => "#F46405",
                Color.Red => "#FF331D",
                Color.Burgundy => "#CD050A",
                Color.Blue => "#0070C0",
                Color.Brown => "#C45911",
                Color.Purple => "#7030A0",
                Color.Gold => "#DDC515",
                Color.DarkGreen => "#007040",
                Color.Gray => "#7F7F7F",
                _ => "#FFFFFF"
            };
        }
    }
}
