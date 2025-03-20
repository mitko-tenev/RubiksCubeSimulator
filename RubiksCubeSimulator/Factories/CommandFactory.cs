using RubiksCubeSimulator.Commands;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Factories
{
    public class CommandFactory : ICommandFactory
    {
        public IMoveCommand CreateCommand(ICube cube, char move, bool clockwise)
        {
            RubiksCube concreteCube = (RubiksCube)cube;

            switch (char.ToUpper(move))
            {
                case 'U':
                    return new UpCommand(concreteCube, clockwise);
                case 'D':
                    return new DownCommand(concreteCube, clockwise);
                case 'L':
                    return new LeftCommand(concreteCube, clockwise);
                case 'R':
                    return new RightCommand(concreteCube, clockwise);
                case 'F':
                    return new FrontCommand(concreteCube, clockwise);
                case 'B':
                    return new BackCommand(concreteCube, clockwise);
                default:
                    throw new ArgumentException($"Unknown move: {move}");
            }
        }
    }
}
