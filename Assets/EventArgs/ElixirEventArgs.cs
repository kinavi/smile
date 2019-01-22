using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.EventArgs
{
    public enum ElixirType { Helth, Mana }

    public class ElixirEventArgs
    {
        public ElixirType Type { get; }
        public float Points { get; }

        public ElixirEventArgs(ElixirType type, float points)
        {
            Type = type;
            Points = points;
        }
    }
}
