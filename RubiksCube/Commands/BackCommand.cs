using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Commands
{
    public class BackCommand : MoveCommand
    {
        public BackCommand(RubiksCube cube, bool clockwise) : base(cube, clockwise) { }

        public override void Execute()
        {
            cube.TurnBack(clockwise);
        }

        public override void Undo()
        {
            cube.TurnBack(!clockwise);
        }

        public override string GetDescription()
        {
            return clockwise ? "B" : "B'";
        }
    }
}
