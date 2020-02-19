using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASAMarsRoverHandler
{
    internal class Rover
    {
        private int[] plateau;
        private char[] commands;
        private RoverPosition position;

        public int[] Plateau { get => plateau; set => plateau = value; }
        internal RoverPosition Position { get => position; set => position = value; }
        public char[] Commands { get => commands; set => commands = value; }

        internal Rover()
        {
            Plateau = new int[2] { 0, 0 };
            Position = new RoverPosition();
            Commands = new char[] { };
        }
        internal Rover(int[] plateau, RoverPosition position, char[] commands)
        {
            Plateau = plateau;
            Position = position;
            Commands = commands;
        }

        internal void ApplyCommandsToRover()
        {
            for (int i = 0; i < Commands.Length; i++)
            {
                switch (Commands[i])
                {
                    case 'L':
                        {
                            Position.Direction = TurnLeft(Position.Direction);
                            break;
                        }
                    case 'R':
                        {
                            Position.Direction = TurnRight(Position.Direction);
                            break;
                        }
                    case 'M':
                        {
                            Position.Coords = Move(Position, Plateau);
                            break;
                        }
                    default:
                        throw new Exception("Wrong Command for rover!");
                }
            }
        }

        private int[] Move(RoverPosition final, int[] size)
        {
            switch (final.Direction)
            {
                case 'N':
                    {
                        if (final.Coords[1] < size[1])
                            final.Coords[1] += 1;
                        break;
                    }
                case 'E':
                    {
                        if (final.Coords[0] > 0)
                            final.Coords[0] -= 1;
                        break;
                    }
                case 'S':
                    {
                        if (final.Coords[1] > 0)
                            final.Coords[1] -= 1;
                        break;
                    }
                case 'W':
                    {
                        if (final.Coords[0] < size[0])
                            final.Coords[0] += 1;
                        break;
                    }
                default:
                    throw new Exception("Unexpected direction: " + final.Direction);
            }
            return final.Coords;
        }

        private char TurnLeft(char direction)
        {
            switch (direction)
            {
                case 'N':
                    return 'E';
                case 'E':
                    return 'S';
                case 'S':
                    return 'W';
                case 'W':
                    return 'N';
                default:
                    throw new Exception("Unexpected direction: " + direction);
            }
        }

        private char TurnRight(char direction)
        {
            switch (direction)
            {
                case 'N':
                    return 'W';
                case 'W':
                    return 'S';
                case 'S':
                    return 'E';
                case 'E':
                    return 'N';
                default:
                    throw new Exception("Unexpected direction: " + direction);
            }
        }

    }
}
