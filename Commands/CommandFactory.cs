using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Commands
{
    public static class CommandFactory
    {
        public static IMoveCommand CreateCommand(RubiksCube cube, char move, bool clockwise)
        {
            switch (char.ToUpper(move))
            {
                case 'U':
                    return new UpCommand(cube, clockwise);
                case 'D':
                    return new DownCommand(cube, clockwise);
                case 'L':
                    return new LeftCommand(cube, clockwise);
                case 'R':
                    return new RightCommand(cube, clockwise);
                case 'F':
                    return new FrontCommand(cube, clockwise);
                case 'B':
                    return new BackCommand(cube, clockwise);
                default:
                    throw new ArgumentException($"Unknown move: {move}");
            }
        }
    }
}
