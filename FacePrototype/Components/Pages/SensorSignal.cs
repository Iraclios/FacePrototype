using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacePrototype.Components.Pages
{
    internal class SensorSignal
    {
        public string Name { get; private set; }
        public double Value { get; set; }
        public Position Position { get; private set; }
        public bool IsVisible { get; set; }

        public SensorSignal(string name, Position position = Position.Center, bool isVisible = false, double signalValue = 0)
        {
            Name = name;
            Value = signalValue;
            Position = position;
            IsVisible = isVisible;
        }
    }
    enum Position
    {
        Center,
        Left,
        Right
    }
}
