using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASAMarsRoverHandler
{
    internal class RoverPosition
    {
        private int[] coords;
        private char direction;

        internal int[] Coords { get => coords; set => coords = value; }
        internal char Direction { get => direction; set => direction = value; }
        internal RoverPosition()
        {
            Coords = new int[2] { 0, 0 };
            Direction = ' ';
        }
        internal RoverPosition(int[] coords, char dir)
        {
            Coords = coords;
            Direction = dir;
        }
        public override string ToString()
        {
            return Coords[0] + " " + Coords[1] + " " + Direction.ToString();
        }
    }
}
