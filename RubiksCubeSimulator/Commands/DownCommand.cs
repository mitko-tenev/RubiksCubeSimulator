using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Commands
{
    public class DownCommand : MoveCommand
    {
        public DownCommand(RubiksCube cube, bool clockwise) : base(cube, clockwise) { }

        public override void Execute()
        {
            cube.TurnDown(clockwise);
        }

        public override void Undo()
        {
            cube.TurnDown(!clockwise);
        }

        public override string GetDescription()
        {
            return clockwise ? "D" : "D'";
        }
    }
}
