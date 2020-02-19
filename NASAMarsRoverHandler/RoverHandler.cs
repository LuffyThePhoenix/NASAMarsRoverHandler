using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASAMarsRoverHandler
{
    internal class RoverHandler
    {

        internal void HandleRovers()
        {
            try
            {
                string inputFile = @"D:\input.txt";
                string outFile = @"D:\Output.txt";
                int[] pSize = new int[2];
                if (File.Exists(outFile))
                    File.Delete(outFile);
                using (StreamReader sr = new StreamReader(inputFile))
                {
                    if (!sr.EndOfStream)
                    {
                        pSize = ReadBoundaries(sr.ReadLine());
                    }
                    while (!sr.EndOfStream)
                    {
                        RoverPosition position = InitializeRoverPosition(sr.ReadLine());
                        char[] commands = sr.ReadLine().ToCharArray();
                        Rover rvr = new Rover(pSize, position, commands);
                        rvr.ApplyCommandsToRover();
                        using (StreamWriter sw = new StreamWriter(outFile, true))
                        {
                            sw.WriteLine(rvr.Position.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private RoverPosition InitializeRoverPosition(string v)
        {
            string[] sArray = v.Split();
            RoverPosition rp = new RoverPosition();
            if (sArray.Length != 3)
            {
                throw new Exception("Wrong Position Format!");
            }
            rp.Coords = new int[2];
            int i = 0;
            for (; i < 2; i++)
            {
                if (!int.TryParse(sArray[i], out rp.Coords[i]))
                {
                    throw new Exception("Could not read coordinates for" + i.ToString() + "!");
                }
            }
            rp.Direction = char.Parse(sArray[i]);
            return rp;
        }

        private int[] ReadBoundaries(string v)
        {
            string[] sArray = v.Split();
            int[] size = new int[2];
            if (sArray.Length != 2)
            {
                throw new Exception("Wrong size format!");
            }
            for (int i = 0; i < sArray.Length; i++)
            {
                if (!int.TryParse(sArray[i], out size[i]))
                {
                    throw new Exception("Could not read size element for" + i.ToString() + "!");
                }
            }
            return size;
        }
    }

}

