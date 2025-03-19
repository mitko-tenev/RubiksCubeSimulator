using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Commands
{
    public abstract class MoveCommand : IMoveCommand
    {
        protected readonly RubiksCube cube;
        protected readonly bool clockwise;

        public MoveCommand(RubiksCube cube, bool clockwise)
        {
            this.cube = cube;
            this.clockwise = clockwise;
        }

        public abstract void Execute();
        public abstract void Undo();
        public abstract string GetDescription();
    }
}
