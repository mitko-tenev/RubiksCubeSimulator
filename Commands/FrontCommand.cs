using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Commands
{
    public class FrontCommand : MoveCommand
    {
        public FrontCommand(RubiksCube cube, bool clockwise) : base(cube, clockwise) { }

        public override void Execute()
        {
            cube.TurnFront(clockwise);
        }

        public override void Undo()
        {
            cube.TurnFront(!clockwise);
        }

        public override string GetDescription()
        {
            return clockwise ? "F" : "F'";
        }
    }
}
