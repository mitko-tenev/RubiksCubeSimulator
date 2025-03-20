using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Commands
{
    public class RightCommand : MoveCommand
    {
        public RightCommand(RubiksCube cube, bool clockwise) : base(cube, clockwise) { }

        public override void Execute()
        {
            cube.TurnRight(clockwise);
        }

        public override void Undo()
        {
            cube.TurnRight(!clockwise);
        }

        public override string GetDescription()
        {
            return clockwise ? "R" : "R'";
        }
    }

}
