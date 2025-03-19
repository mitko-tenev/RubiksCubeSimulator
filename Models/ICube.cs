using RubiksCubeSimulator.Commands;

namespace RubiksCubeSimulator.Models
{
    public interface ICube
    {
        char[,] GetFace(CubeFace face);
        void ApplyMove(IMoveCommand command);
        void Reset();
    }
}
