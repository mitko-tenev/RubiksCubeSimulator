using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Commands
{
    public class UpCommand : MoveCommand
    {
        public UpCommand(RubiksCube cube, bool clockwise) : base(cube, clockwise) { }

        public override void Execute()
        {
            cube.TurnUp(clockwise);
        }

        public override void Undo()
        {
            cube.TurnUp(!clockwise);
        }

        public override string GetDescription()
        {
            return clockwise ? "U" : "U'";
        }
    }
}
