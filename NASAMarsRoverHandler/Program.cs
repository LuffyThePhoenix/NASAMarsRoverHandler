using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASAMarsRoverHandler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RoverHandler rH = new RoverHandler();
            rH.HandleRovers();
        }
    }
}
