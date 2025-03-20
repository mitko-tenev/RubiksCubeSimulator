using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
