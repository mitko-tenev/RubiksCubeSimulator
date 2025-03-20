using RubiksCubeSimulator.Models;

namespace RubiksCubeSimulator.Views
{
    public interface ICubeView
    {
        void DisplayCube(ICube cube);
        void DisplayMessage(string message);
        string? GetUserInput();
        void DisplayHelp();
    }
}
