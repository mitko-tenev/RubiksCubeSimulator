using RubiksCubeSimulator.Commands;
using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Factories
{
    public interface ICommandFactory
    {
        IMoveCommand CreateCommand(ICube cube, char move, bool clockwise);
    }
}