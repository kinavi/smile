using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.EventArgs
{
    public enum BottleType { Helth, Mana }

    public class BottleEventArgs
    {
        public BottleType Type { get; }
        public float Points { get; }

        public BottleEventArgs(BottleType type, float points)
        {
            Type = type;
            Points = points;
        }
    }
}
